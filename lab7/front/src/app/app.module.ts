import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { RouterModule, Routes } from "@angular/router";


import { AppComponent }  from './app.component';
import { MainContainerComponent } from './main-container/main-container.component';
import { HeaderComponent } from './header/header.component';
import { FilterComponent } from './filter/filter.component';
import { CardComponent } from './card/card.component';
import { CardCatalogComponent } from './card-catalog/card-catalog.component';
import { AddCardComponent } from './add-card/add-card.component';
import { BikeDescriptionComponent } from './bike-description/bike-description.component';
import { CommentsComponent } from './comments/comments.component';
import { AddBikeComponent } from './add-bike/add-bike.component';

const routes: Routes = [
    {path: '', component: MainContainerComponent},
    {path: 'add-bike', component: AddBikeComponent},
    {path: 'description', component: BikeDescriptionComponent}
];

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot(routes, {useHash: true})
    ],
    declarations: [
        AppComponent,
        MainContainerComponent,
        HeaderComponent,
        FilterComponent,
        CardComponent,
        CardCatalogComponent,
        AddCardComponent,
        BikeDescriptionComponent,
        CommentsComponent,
        AddBikeComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
