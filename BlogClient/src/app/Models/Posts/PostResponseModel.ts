export class PostResponseModel {
    id: number;
    title: string;
    content: string;
    excerpt: string;
    isPublished: boolean;
    createdAt: Date;
    updatedAt: Date;

    categoryId: number; 
    tagId: number;

    categoryName?: string; 
    tagName?: string;

    constructor(id: number, title: string, content: string, excerpt: string, isPublished: boolean, createdAt: Date, updatedAt: Date, categoryId: number, tagId: number) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.excerpt = excerpt;
        this.isPublished = isPublished;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
        this.categoryId = categoryId; // Eklendi
        this.tagId = tagId;           // Eklendi
    }
}