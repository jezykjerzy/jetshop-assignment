import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CarRentalService } from '../shared/car-rental.service';
import { Car } from '../shared/car.model';

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
    this.service.refreshCars();
  }
  populateForm(selectedCar: Car): void {
    this.service.formData = Object.assign({}, selectedCar);
  }

  deleteCar(carId: number) {
    this.service.deleteCar(carId).subscribe(
      res => {
        this.service.refreshCars();
        this.toastrService.info("Deleted successfully", "Car administration panel")
      },
      err => {
        console.log(err);
      }

    )
  }

}
