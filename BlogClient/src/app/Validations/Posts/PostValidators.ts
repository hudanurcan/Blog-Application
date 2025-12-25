import { Validators, ValidatorFn } from "@angular/forms";

export const PostValidators = {
    // Title: Boş olamaz 
    title: (): ValidatorFn[] => [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(200)
    ],

    // Content: Boş olamaz
    content: (): ValidatorFn[] => [
        Validators.required
    ],

    // Excerpt: UI'da opsiyonel
    excerpt: (): ValidatorFn[] => [
        Validators.maxLength(500)
    ],

    // Kategori ve Etiket seçimi: İş kuralı gereği ilişkili olmalıdır
    relation: (): ValidatorFn[] => [
        Validators.required,
        Validators.min(1) 
    ]
};