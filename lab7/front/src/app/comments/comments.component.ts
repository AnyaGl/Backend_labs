import { Component } from '@angular/core';

@Component({
    selector: 'app-comments',
    templateUrl: './comments.component.html',
    styleUrls: ['./comments.component.css']
})
export class CommentsComponent{
    comments: string[] = ["23131", "123123124", "124343532"]
}
