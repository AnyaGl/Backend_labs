import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CommentModel } from '../models/comment.model';
import { HttpClient } from '@angular/common/http';
import { API } from '../config';

@Injectable({
    providedIn: 'root'
})

export class CommentService {

    constructor(private http: HttpClient) {
    }

    public CreateComment(name: string, text: string, bikeId: number)
    {
        const body = { name, text, bikeId };
        return this.http.post(API + `api/Comment/create-comment`, body);
    }

    public GetCommentsByBikeId(bikeId: number)
    {
        return this.http.get<CommentModel[]>(API + `api/Comment/get-comments-by-bike-id/${bikeId}`)
    }
}
