import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CarsService } from 'src/app/shared/cars.service';
import { Car } from 'src/app/shared/car.model';

@Component({
  selector: 'app-cars-table',
  templateUrl: './cars-table.component.html',
  styleUrls: []
})
export class CarsTableComponent implements OnInit {

  constructor(public service:CarsService,
    private toastrService:ToastrService) { }

  ngOnInit(): void {
  }
  
  populateForm(selectedCar:Car): void{
    this.service.formData = Object.assign({},selectedCar);
  }

  deleteCar(carId:number){
    this.service.deleteCar(carId).subscribe(
      res => {
        this.service.refreshCars();
        this.toastrService.info("Deleted successfully", "Car administration panel")
      },
      err =>{
        console.log(err);
      }

    )
  }
}
