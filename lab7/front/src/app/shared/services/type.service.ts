import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TypeModel } from '../models/type.model';
import { HttpClient } from '@angular/common/http';
import { API } from '../config';

@Injectable({
    providedIn: 'root'
})

export class TypeService {

    constructor(private http: HttpClient) {
    }

    public GetTypes()
    {
        return this.http.get<TypeModel[]>(API + `api/Type/get-types`);
    }
}
