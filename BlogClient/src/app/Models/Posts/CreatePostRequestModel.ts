import { BasePostViewModel } from "./BasePostViewModel";

export class CreatePostRequestModel extends BasePostViewModel {
    constructor(
        title: string, 
        content: string, 
        excerpt: string, 
        isPublished: boolean, 
        categoryId: number, 
        tagId: number
    ) {
        super(title, content, excerpt, isPublished, categoryId, tagId);
    }
}