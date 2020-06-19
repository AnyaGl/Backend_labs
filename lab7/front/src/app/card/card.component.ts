import { Component, Input } from '@angular/core';
import { BikeModel } from '../shared/models/bike.model';
import { ImageApi } from '../shared/config'

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
    styleUrls: ['./card.component.css']
})
export class CardComponent {
    @Input() bike: BikeModel;
    imgPath = ImageApi;
}
