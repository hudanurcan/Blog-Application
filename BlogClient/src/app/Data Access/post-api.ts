import { Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { API_Config } from "../api.config";
import { PostResponseModel } from "../Models/Posts/PostResponseModel";
import { CreatePostRequestModel } from "../Models/Posts/CreatePostRequestModel";
import { UpdatePostRequestModel } from "../Models/Posts/UpdatePostRequestModel";

@Injectable({ providedIn: 'root' })
export class PostApi {
    private http = inject(HttpClient);
    private readonly url = `${API_Config.baseUrl}/${API_Config.endpoints.post}`;

    async getAll(): Promise<PostResponseModel[]> {
        return await lastValueFrom(this.http.get<PostResponseModel[]>(this.url));
    }

    async getById(id: number): Promise<PostResponseModel> {
        return await lastValueFrom(this.http.get<PostResponseModel>(`${this.url}/${id}`));
    }

    async create(body: CreatePostRequestModel): Promise<any> {
        return await lastValueFrom(this.http.post(this.url, body));
    }

    async update(body: UpdatePostRequestModel): Promise<any> {
        const updateUrl = `${this.url}/${body.id}`;
        return await lastValueFrom(this.http.put(updateUrl, body));
    }

    async deleteById(id: number): Promise<any> {
        const deleteUrl = `${this.url}/${id}`;
        return await lastValueFrom(this.http.delete(deleteUrl));
    }
}