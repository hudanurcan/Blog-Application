import { Component, signal, inject, OnInit } from '@angular/core';
import { AbstractControl, ReactiveFormsModule } from '@angular/forms';
import { TagApi } from '../../Data Access/tag-api'; 
import { TagResponseModel } from '../../Models/Tags/TagResponseModel';
import { createTagForm, toCreateTagRequest } from '../../Validations/Tags/CreateTagFormFactory';
import { updateTagForm, toUpdateTagRequest } from '../../Validations/Tags/UpdateTagFormFactory';
@Component({
  selector: 'app-tag-operation',
  imports: [ReactiveFormsModule],
  templateUrl: './tag-operation.html',
  styleUrl: './tag-operation.css',
})
export class TagOperation implements OnInit {
  private tagApi = inject(TagApi);

  protected tags = signal<TagResponseModel[]>([]);
  protected selectedTag = signal<TagResponseModel | null>(null);

  protected createForm = createTagForm();
  protected updateForm = updateTagForm();

  private async refreshTags(): Promise<void> {
    try {
      const values = await this.tagApi.getAll();
      this.tags.set(values);
    } catch (error) {
      console.log("Etiket listesi alınamadı", error);
    }
  }

  async ngOnInit(): Promise<void> {
    await this.refreshTags();
  }

  async onCreate(): Promise<void> {
    if (this.createForm.invalid) {
      this.createForm.markAllAsTouched();
      return;
    }
    const req = toCreateTagRequest(this.createForm);
    await this.tagApi.create(req);
    this.createForm.reset();
    await this.refreshTags();
  }

  startUpdate(tag: TagResponseModel) {
    this.selectedTag.set(tag);
    this.updateForm.patchValue({
      id: tag.id,
      tagName: tag.tagName
    }, { emitEvent: false });
  }

  cancelUpdate() {
    this.selectedTag.set(null);
    this.updateForm.reset({ id: 0, tagName: '' });
  }

  async onUpdate() {
    if (this.updateForm.invalid) {
      this.updateForm.markAllAsTouched();
      return;
    }
    const req = toUpdateTagRequest(this.updateForm);
    await this.tagApi.update(req);
    this.cancelUpdate();
    await this.refreshTags();
  }

  async onDelete(id: number): Promise<void> {
    const confirmDelete = window.confirm(`ID'si ${id} olan etiketi silmek istediğinize emin misiniz?`);
    if (!confirmDelete) return;

    try {
      await this.tagApi.deleteById(id);
      this.tags.update((x) => x.filter((t) => t.id !== id));
      if (this.selectedTag()?.id === id) this.selectedTag.set(null);
    } catch (error) {
      console.log(error);
    }
  }

  protected labels: Record<string, string> = {
    tagName: 'Etiket Adı',
    id: 'Id',
  };

  protected getErrorMessageByName(form: any, controlName: string): string | null {
    const control = form.controls[controlName];
    if (!control || !control.invalid || (!control.touched && !control.dirty)) return null;
    
    const label = this.labels[controlName] ?? controlName;
    if (control.hasError('required')) return `${label} zorunludur`;
    if (control.hasError('maxlength')) return `${label} en fazla ${control.errors?.['maxlength'].requiredLength} karakter olabilir`;
    return `${label} geçersiz`;
  }
}
