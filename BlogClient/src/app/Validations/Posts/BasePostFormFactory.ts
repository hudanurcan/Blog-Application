import { FormControl } from "@angular/forms";
import { PostValidators } from "./PostValidators";

export type basePostForm = {
  title: FormControl<string>;
  content: FormControl<string>;
  excerpt: FormControl<string>;
  isPublished: FormControl<boolean>;
  categoryId: FormControl<number>;
  tagId: FormControl<number>;
};

export function basePostForm(): basePostForm {
  return {
    title: new FormControl<string>('', { 
      nonNullable: true, 
      validators: PostValidators.title() 
    }),
    content: new FormControl<string>('', { 
      nonNullable: true, 
      validators: PostValidators.content() 
    }),
    excerpt: new FormControl<string>('', { 
      nonNullable: true, 
      validators: PostValidators.excerpt() 
    }),
    isPublished: new FormControl<boolean>(false, { 
      nonNullable: true 
    }),
    categoryId: new FormControl<number>(0, { 
      nonNullable: true, 
      validators: PostValidators.relation() 
    }),
    tagId: new FormControl<number>(0, { 
      nonNullable: true, 
      validators: PostValidators.relation() 
    })
  };
}