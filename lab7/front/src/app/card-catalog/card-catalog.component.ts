import {Component, OnChanges, OnInit} from '@angular/core';
import { BikeModel } from '../shared/models/bike.model';
import { BikeService } from '../shared/services/bike.service';

@Component({
    selector: 'app-card-catalog',
    templateUrl: './card-catalog.component.html',
    styleUrls: ['./card-catalog.component.css']
})
export class CardCatalogComponent implements OnInit{

    bikes: BikeModel[] = [];
    constructor(private bikeService: BikeService) {
        this.bikeService.bikes.subscribe(data => {
            this.bikes = data;
        });
    }

    ngOnChanges() {
        this.bikeService.bikes.subscribe(data => {
            this.bikes = data;
        });
    }

    public ngOnInit() {
        this.bikeService.bikes.subscribe(data => {
            this.bikes = data;
        });
    }
}

