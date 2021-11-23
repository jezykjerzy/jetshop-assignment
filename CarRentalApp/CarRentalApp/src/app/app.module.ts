import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CarsComponent } from './cars/cars.component';
import { CarDetailFormComponent } from './cars/car-detail-form/car-detail-form.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { ToastrModule } from 'ngx-toastr'
import { FormsModule } from '@angular/forms';
import { CarsRentalComponent } from './cars-rental/cars-rental.component';
import { CarRentalFormComponent } from './cars-rental/car-rental-form/car-rental-form.component';
import { CarsTableComponent } from './cars/cars-table/cars-table.component';
import { AvailableCarsTableComponent } from './cars-rental/available-cars-table/available-cars-table.component';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    CarsComponent,
    CarDetailFormComponent,
    CarsRentalComponent,
    CarRentalFormComponent,
    CarsTableComponent,
    AvailableCarsTableComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
