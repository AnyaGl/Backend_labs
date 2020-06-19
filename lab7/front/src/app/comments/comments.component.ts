import { Component } from '@angular/core';
import { CommentModel } from '../shared/models/comment.model';
import { CommentService } from '../shared/services/comment.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-comments',
    templateUrl: './comments.component.html',
    styleUrls: ['./comments.component.css']
})
export class CommentsComponent{

    comments: CommentModel[] = [];

    name: string = '';
    text: string = '';

    constructor(private commentService: CommentService, private route: ActivatedRoute) {
        this.route.params.subscribe(params => {
            this.commentService.GetCommentsByBikeId(params["id"]).subscribe(data => {
                this.comments = data;
            });
        });
    }

    onUpdate(): void
    {
        this.route.params.subscribe(params => {
            this.commentService.GetCommentsByBikeId(params["id"]).subscribe(data => {
                this.comments = data;
            });
        })
    }
}
