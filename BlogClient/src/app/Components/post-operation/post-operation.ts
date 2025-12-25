import { Component, signal, inject, OnInit } from '@angular/core';
import { AbstractControl, ReactiveFormsModule } from '@angular/forms';
import { PostApi } from '../../Data Access/post-api';
import { CategoryApi } from '../../Data Access/category-api';
import { TagApi } from '../../Data Access/tag-api';
import { PostResponseModel } from '../../Models/Posts/PostResponseModel';
import { CategoryResponseModel } from '../../Models/Categories/CategoryResponseModel';
import { TagResponseModel } from '../../Models/Tags/TagResponseModel';
import { createPostForm, toCreatePostRequest } from '../../Validations/Posts/CreatePostFormFactory';
import { updatePostForm, toUpdatePostRequest } from '../../Validations/Posts/UpdatePostFormFactory';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-post-operation',
  imports: [ReactiveFormsModule, DatePipe],
  templateUrl: './post-operation.html',
  styleUrl: './post-operation.css',
})
export class PostOperation implements OnInit{
  private postApi = inject(PostApi);
  private categoryApi = inject(CategoryApi);
  private tagApi = inject(TagApi);

  // Veri Listeleri (Signals)
  protected posts = signal<PostResponseModel[]>([]);
  protected categories = signal<CategoryResponseModel[]>([]);
  protected tags = signal<TagResponseModel[]>([]);
  protected selectedPost = signal<PostResponseModel | null>(null);

  // Formlar
  protected createForm = createPostForm();
  protected updateForm = updatePostForm();

  async ngOnInit(): Promise<void> {
    await this.refreshData();
  }

  private async refreshData(): Promise<void> {
    try {
      const [postList, catList, tagList] = await Promise.all([
        this.postApi.getAll(),
        this.categoryApi.getAll(),
        this.tagApi.getAll()
      ]);
      this.posts.set(postList);
      this.categories.set(catList);
      this.tags.set(tagList);
    } catch (error) {
      console.error("Veriler yüklenemedi", error);
    }
  }

  async onCreate(): Promise<void> {
    if (this.createForm.invalid) {
      this.createForm.markAllAsTouched();
      return;
    }
    const req = toCreatePostRequest(this.createForm);
    await this.postApi.create(req);
    this.createForm.reset();
    await this.refreshData();
  }

  startUpdate(post: PostResponseModel) {
    this.selectedPost.set(post);
    this.updateForm.patchValue({
      id: post.id,
      title: post.title,
      content: post.content,
      excerpt: post.excerpt,
      isPublished: post.isPublished,
      categoryId: post.categoryId, 
      tagId: post.tagId
    }, { emitEvent: false });
  }

  async onUpdate(): Promise<void> {
    if (this.updateForm.invalid) {
      this.updateForm.markAllAsTouched();
      return;
    }
    const req = toUpdatePostRequest(this.updateForm);
    await this.postApi.update(req);
    this.cancelUpdate();
    await this.refreshData();
  }

  cancelUpdate() {
    this.selectedPost.set(null);
    this.updateForm.reset();
  }

  async onDelete(id: number): Promise<void> {
    if (window.confirm(`ID'si ${id} olan yazıyı silmek istediğinize emin misiniz?`)) {
      await this.postApi.deleteById(id);
      await this.refreshData();
    }
  }

  // Hata Mesajı Yönetimi
  protected labels: Record<string, string> = {
    title: 'Başlık',
    content: 'İçerik',
    categoryId: 'Kategori',
    tagId: 'Etiket'
  };

  protected getErrorMessageByName(form: any, controlName: string): string | null {
    const control = form.controls[controlName];
    if (!control || !control.invalid || (!control.touched && !control.dirty)) return null;
    const label = this.labels[controlName] ?? controlName;
    if (control.hasError('required')) return `${label} zorunludur`;
    if (control.hasError('min')) return `Lütfen bir ${label} seçiniz`;
    return `${label} geçersiz`;
  }
}
