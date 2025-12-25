import { FormControl, FormGroup, Validators } from "@angular/forms";
import { UpdatePostRequestModel } from "../../Models/Posts/UpdatePostRequestModel";
import { basePostForm } from "./BasePostFormFactory"; 

export type UpdatePostForm = FormGroup<{
    id: FormControl<number>;
    title: FormControl<string>;
    content: FormControl<string>;
    excerpt: FormControl<string>;
    isPublished: FormControl<boolean>;
    categoryId: FormControl<number>;
    tagId: FormControl<number>;
}>;

export function updatePostForm(): UpdatePostForm {
    const base = basePostForm();

    return new FormGroup({
       
        id: new FormControl(0, {
            nonNullable: true,
            validators: [Validators.required, Validators.min(1)],
        }),
        ...base, 
    });
}

export function toUpdatePostRequest(form: UpdatePostForm): UpdatePostRequestModel {
    return {
        id: form.controls.id.value,                 
        title: form.controls.title.value,             
        content: form.controls.content.value,        
        excerpt: form.controls.excerpt.value,         
        isPublished: form.controls.isPublished.value, 
        categoryId: form.controls.categoryId.value,    
        tagId: form.controls.tagId.value              
    };
}