import { Component } from '@angular/core';
import { ImageApi } from '../shared/config';
import { BikeModel } from '../shared/models/bike.model';
import { ActivatedRoute } from '@angular/router';
import { BikeService } from '../shared/services/bike.service';

@Component({
    selector: 'app-bike-description',
    templateUrl: './bike-description.component.html',
    styleUrls: ['./bike-description.component.css']
})
export class BikeDescriptionComponent{
    imgPath = ImageApi;
    bike: BikeModel;

    constructor(private route: ActivatedRoute, private bikeService: BikeService)
    {
        this.route.params.subscribe(params => {
            this.bikeService.GetBikeById(params["id"]).subscribe(bike => {
                this.bike = bike;
            })
        });
    }
}
