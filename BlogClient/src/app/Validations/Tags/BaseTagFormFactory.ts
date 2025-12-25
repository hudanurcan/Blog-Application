import { FormControl } from "@angular/forms";
import { TagValidators } from "./TagValidators";

export type baseTagForm = {
    tagName: FormControl<string>;
};

export function baseTagForm() : baseTagForm {
    return {
        tagName: new FormControl<string>('',{nonNullable:true, validators:TagValidators.tagName()}),
    };
}