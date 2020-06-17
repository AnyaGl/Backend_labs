import { Component } from '@angular/core';

@Component({
    selector: 'app-add-bike',
    templateUrl: './add-bike.component.html',
    styleUrls: ['./add-bike.component.css']
})
export class AddBikeComponent{
    people: string[] = ["Мужской", "Женский", "Детский"];
}
