export abstract class BasePostViewModel {
    title: string;
    content: string;
    excerpt: string;
    isPublished: boolean;
    categoryId: number;
    tagId: number;

    constructor(title: string, content: string, excerpt: string, isPublished: boolean, categoryId: number, tagId: number) {
        this.title = title;
        this.content = content;
        this.excerpt = excerpt;
        this.isPublished = isPublished;
        this.categoryId = categoryId;
        this.tagId = tagId;
    }
}