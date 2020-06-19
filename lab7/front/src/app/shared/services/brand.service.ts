import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { BrandModel } from '../models/brand.model';
import { HttpClient } from '@angular/common/http';
import { API } from '../config';

@Injectable({
    providedIn: 'root'
})

export class BrandService {

    constructor(private http: HttpClient) {
    }

    public GetBrands()
    {
        return this.http.get<BrandModel[]>(API + `api/Brand/get-brands`)
    }
}
