import { Validators, ValidatorFn } from "@angular/forms"; // ValidatorFn : validationları aktarmak için

export const CategoryValidators = {
    name : () : ValidatorFn[] =>  [ 
        Validators.required,
        Validators.minLength(2)],

    description: (): ValidatorFn[] => [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(100),
    ],
};