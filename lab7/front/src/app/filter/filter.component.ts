import { Component } from '@angular/core';
import { PersonModel } from '../shared/models/person.model';
import { PersonService } from '../shared/services/person.service';
import { TypeService } from '../shared/services/type.service';
import { TypeModel } from '../shared/models/type.model';
import { BrandService } from '../shared/services/brand.service';
import { BrandModel } from '../shared/models/brand.model';
import { BikeService } from '../shared/services/bike.service';

@Component({
    selector: 'app-filter',
    templateUrl: './filter.component.html',
    styleUrls: ['./filter.component.css']
})
export class FilterComponent {
    people: PersonModel[] = [];
    bikeTypes: TypeModel[] = [];
    brands: BrandModel[] = [];

    minPrice: number;
    maxPrice: number;
    personId: number;
    minDiameter: number;
    maxDiameter: number;
    brandId: number;
    typeId: number;

    constructor(private personService: PersonService, private typeService: TypeService, private brandService: BrandService, private bikeService: BikeService)
    {
        this.personService.GetPeople().subscribe(data => {
            this.people = data;
        });

        this.typeService.GetTypes().subscribe(data => {
            this.bikeTypes = data;
        });

        this.brandService.GetBrands().subscribe(data => {
            this.brands = data;
        });
    }

    findBikesByFilter(): void
    {
        if (this.AnyOfParametersIsEmpty())
        {
            alert('Заполните все поля')
            return;
        }
        this.bikeService.GetBikesByFilter(this.minPrice, this.maxPrice, this.personId, this.minDiameter, this.maxDiameter, this.brandId, this.typeId);
    }

    AnyOfParametersIsEmpty(): boolean
    {
        if (!this.minPrice || !this.maxPrice || !this.personId || !this.minDiameter || !this.maxDiameter || !this.brandId || !this.typeId)
        {
            return true;
        }
    }
}


