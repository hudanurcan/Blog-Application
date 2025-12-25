import { BasePostViewModel } from "./BasePostViewModel";

export class UpdatePostRequestModel extends BasePostViewModel {
    id: number;

    constructor(
        id: number,
        title: string,
        content: string,
        excerpt: string,
        isPublished: boolean,
        categoryId: number,
        tagId: number
    ) {
        super(title, content, excerpt, isPublished, categoryId, tagId);
        this.id = id;
    }
}