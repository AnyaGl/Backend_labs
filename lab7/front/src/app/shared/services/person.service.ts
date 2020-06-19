import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PersonModel } from '../models/person.model';
import { HttpClient } from '@angular/common/http';
import { API } from '../config';

@Injectable({
    providedIn: 'root'
})

export class PersonService {

    constructor(private http: HttpClient) {
    }

    public GetPeople()
    {
        return this.http.get<PersonModel[]>(API + `api/Person/get-people`)
    }
}
