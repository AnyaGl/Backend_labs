import { Component } from '@angular/core';
import { PersonModel } from '../shared/models/person.model';
import { PersonService } from '../shared/services/person.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BikeService } from '../shared/services/bike.service';
import { Router } from '@angular/router';
import {CardCatalogComponent} from "../card-catalog/card-catalog.component";

@Component({
    selector: 'app-add-bike',
    templateUrl: './add-bike.component.html',
    styleUrls: ['./add-bike.component.css']
})
export class AddBikeComponent{
    form: FormGroup;
    people: PersonModel[] = [];

    constructor(private personService: PersonService, private formBuilder: FormBuilder,  private bikeService: BikeService, private router: Router)
    {
        this.personService.GetPeople().subscribe(data => {
            this.people = data;
        });

        this.form = formBuilder.group({
            name: ['', [Validators.required]],
            price: ['', [Validators.required]],
            person: ['', [Validators.required]],
            diameter: ['', [Validators.required]],
            brand: ['', [Validators.required]],
            type: ['', [Validators.required]],
            description: ['', [Validators.required]],
            file: ['', [Validators.required]]
        })
    }

    uploadFile(): void
    {
        const uploader = document.getElementById("file_uploader") as HTMLInputElement;
        uploader.click();
        uploader.onchange = (event: any) => {
            if (!event.target.files[0].type.indexOf("image"))
            {
                this.form.controls.file.setValue(event.target.files[0]);
            }
            else
            {
                alert('Выбран неверный файл. Загрузите фото.');
            }
        }
    }

    addBike(): void
    {
        const data = this.form.value;
        const formData = new FormData();
        formData.append("Name", data.name);
        formData.append("Diameter", data.diameter);
        formData.append("Price", data.price);
        formData.append("Description", data.description);
        formData.append("PersonId", data.person);
        formData.append("Brand", data.brand);
        formData.append("Type", data.type);
        formData.append("File", data.file);

        this.bikeService.CreateBike(formData).subscribe(_ => window.location.reload(), _ => alert("Не удалось добавить велосипед"));
    }
}
