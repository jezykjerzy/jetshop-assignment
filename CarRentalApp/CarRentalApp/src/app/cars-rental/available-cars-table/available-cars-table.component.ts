//TODO Do a research and introduce templates for table components and forms

import { Component, OnInit } from '@angular/core';
import { CarRentalService } from 'src/app/shared/car-rental.service';
import { Car } from 'src/app/shared/car.model';

@Component({
  selector: 'app-available-cars-table',
  templateUrl: './available-cars-table.component.html',
  styleUrls: []
})
export class AvailableCarsTableComponent implements OnInit {

  constructor(public service:CarRentalService) { }

  ngOnInit(): void {
    this.service.refreshAvailableCars()
  }
  
  populateForm(selectedCar:Car): void{
    this.service.formData.car =Object.assign({},selectedCar);
  }
}
