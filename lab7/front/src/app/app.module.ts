import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from "@angular/router";
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

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
import { AddCommentComponent } from './add-comment/add-comment.component'

const routes: Routes = [
    {path: '', component: MainContainerComponent},
    {path: 'add-bike', component: AddBikeComponent},
    {path: 'description/:id', component: BikeDescriptionComponent}
];

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        FormsModule,
        RouterModule.forRoot(routes, {useHash: true}),
        HttpClientModule,
        ReactiveFormsModule
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
        AddBikeComponent,
        AddCommentComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
