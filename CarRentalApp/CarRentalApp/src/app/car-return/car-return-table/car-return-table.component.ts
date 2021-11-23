import { Component, OnInit } from '@angular/core';
import { CarRental } from 'src/app/shared/car-rental.model';
import { CarReturn } from 'src/app/shared/car-return.model';
import { CarReturnService } from 'src/app/shared/car-return.service';

@Component({
  selector: 'app-car-return-table',
  templateUrl: './car-return-table.component.html',
  styleUrls: []
})
export class CarReturnTableComponent implements OnInit {

  constructor(public service:CarReturnService) { }

  ngOnInit(): void {
    this.service.refreshAvailableRentals()
  }

  populateForm(selectedRental:CarRental): void{
    this.service.formData.carRental = Object.assign({},selectedRental);
  }

}
