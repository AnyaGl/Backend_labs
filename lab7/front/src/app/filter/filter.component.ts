import { Component } from '@angular/core';

@Component({
    selector: 'app-filter',
    templateUrl: './filter.component.html',
    styleUrls: ['./filter.component.css']
})
export class FilterComponent {
    people: string[] = ["Мужской", "Женский", "Детский"];
    brands: string[] = ["Format", "Forward", "Novatrack", "Silverback", "Stels"];
    bikeTypes: string[] = ["Горные велосипеды", "Городские велосипеды", "Шоссейные велосипеды", "Экстримальные велосипеды", "Комфортные велосипеды", "Электровелосипеды"];
}
