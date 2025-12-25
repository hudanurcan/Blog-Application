import { Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { last, lastValueFrom } from "rxjs";
import { API_Config } from "../api.config";
import { TagResponseModel } from "../Models/Tags/TagResponseModel";
import { UpdateTagRequestModel } from "../Models/Tags/UpdateTagRequestModel";
import { CreateTagRequestModel } from "../Models/Tags/CreateTagRequestModel";

@Injectable({providedIn : 'root'})
export class TagApi {
    private http = inject(HttpClient);
    private readonly url = `${API_Config.baseUrl}/${API_Config.endpoints.tag}`;

    async getAll(): Promise<TagResponseModel[]> {
        return await lastValueFrom(this.http.get<TagResponseModel[]>(this.url));
    }

    async create(body: CreateTagRequestModel): Promise<any> {
        return await lastValueFrom(this.http.post(this.url, body));
    }

    async update(body: UpdateTagRequestModel): Promise<any> {
        const updateUrl = `${this.url}/${body.id}`; 
        return await lastValueFrom(this.http.put(updateUrl, body));
    }
    
    async deleteById(id: number): Promise<any> {
        const deleteUrl = `${this.url}/${id}`;
        return await lastValueFrom(this.http.delete(deleteUrl));
    }


}
