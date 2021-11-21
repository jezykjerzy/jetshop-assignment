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

@NgModule({
  declarations: [
    AppComponent,
    CarsComponent,
    CarDetailFormComponent,
    CarsRentalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
