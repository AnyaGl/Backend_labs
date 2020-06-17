import { Component } from '@angular/core';

@Component({
    selector: 'app-card-catalog',
    templateUrl: './card-catalog.component.html',
    styleUrls: ['./card-catalog.component.css']
})
export class CardCatalogComponent {
    bikes: string[] = ["1", "2", "3","1", "2", "3","1", "2"];
}

