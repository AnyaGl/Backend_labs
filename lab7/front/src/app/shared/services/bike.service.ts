import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { BikeModel } from '../models/bike.model';
import { HttpClient } from '@angular/common/http';
import { API } from '../config';

@Injectable({
    providedIn: 'root'
})

export class BikeService {
    bikes: BehaviorSubject<BikeModel[]>;

    constructor(private http: HttpClient) {
        this.bikes = new BehaviorSubject<BikeModel[]>([]);
        this.http.get<BikeModel[]>(API + `api/Bike/get-bikes`).subscribe(data => {
            this.bikes.next(data);
        })
    }

    public GetBikesByFilter(minPrice: number, maxPrice: number, personId: number, minDiameter: number, maxDiameter: number, brandId: number, typeId: number)
    {
        let url = API + `api/Bike/get-bikes-by-filter?minPrice=${minPrice}&maxPrice=${maxPrice}&personId=${personId}&minDiameter=${minDiameter}&maxDiameter=${maxDiameter}&brandId=${brandId}&typeId=${typeId}`;
        this.http.get<BikeModel[]>(url).subscribe(data => {
            this.bikes.next(data);
        })
    }

    public GetBikeById(id)
    {
        return this.http.get<BikeModel>(API + `api/Bike/get-bike-by-id/${id}`)
    }

    public CreateBike(data)
    {
        console.log("add");
        return this.http.post(API + `api/Bike/create-bike`, data);
    }
}
