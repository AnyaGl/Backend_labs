import { Component, EventEmitter, Output } from '@angular/core';
import { CommentService } from '../shared/services/comment.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-add-comment',
    templateUrl: './add-comment.component.html',
    styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent{
    @Output() update: EventEmitter<any> = new EventEmitter<any>();

    name: string = '';
    text: string = '';

    constructor(private commentService: CommentService, private route: ActivatedRoute) {
    }

    addComment(): void
    {
        let bikeId = 0;
        this.route.params.subscribe(params => bikeId = params["id"]);
        this.commentService.CreateComment(this.name, this.text, bikeId).subscribe(x => this.update.emit(null), err => this.update.emit(null))

    }
}
