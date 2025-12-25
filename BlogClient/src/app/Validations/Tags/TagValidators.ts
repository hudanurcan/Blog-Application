import { Validators, ValidatorFn } from "@angular/forms"; // ValidatorFn : validationları aktarmak için

export const TagValidators = {
    tagName : () : ValidatorFn[] =>  [ 
        Validators.required,
    ],
};