import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CarsService } from '../shared/cars.service';
import { Car } from '../shared/car.model';
import { CarRentalService } from '../shared/car-rental.service';
import { CarRental } from '../shared/car-rental.model';

@Component({
  selector: 'app-cars-rental',
  templateUrl: './cars-rental.component.html',
  styles: [
  ]
})
export class CarsRentalComponent implements OnInit {

  constructor(public service: CarRentalService,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshAvailableCars();    
    // this.populateForm(this.service.availableCars[0]);
  }
  populateForm(car: Car): void {
    this.service.formData.car = Object.assign({}, car);
  }
}
