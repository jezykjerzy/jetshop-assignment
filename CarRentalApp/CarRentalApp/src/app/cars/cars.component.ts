import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CarsService } from '../shared/cars.service';
import { Car } from '../shared/car.model';
import { Category } from '../shared/category.model';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styles: [
  ]
})
export class CarsComponent implements OnInit {

  constructor(public service: CarsService,
              private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshCars();
  }
  

}
