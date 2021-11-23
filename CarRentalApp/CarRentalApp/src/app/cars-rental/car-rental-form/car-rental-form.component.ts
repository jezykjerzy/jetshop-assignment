import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CarRental } from 'src/app/shared/car-rental.model';
import { CarRentalService } from 'src/app/shared/car-rental.service';
import { Car } from 'src/app/shared/car.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-car-rental-form',
  templateUrl: './car-rental-form.component.html',
  styleUrls: []
})
export class CarRentalFormComponent implements OnInit {

  constructor(public service:CarRentalService,
              private toastrService:ToastrService,
              private datePipe: DatePipe) { }

  fromDate:any;
  toDate: any;
  birthDayDate:any;

  ngOnInit(): void {

    // TODO init formData with first available car properly
    // this.service.formData.car = this.service.availableCars[0];
    let emptyCar = new Car();
    this.service.formData.car = emptyCar;
    this.setDefaultDates();
    }
// TODO Introduce string model for user input
  setDefaultDates() {
    let todayDate = new Date();
    let tommorowDate = new Date();
    tommorowDate.setDate(todayDate.getDate() + 1);

    this.fromDate = this.datePipe.transform(todayDate, 'yyyy-MM-dd');
    this.toDate = this.datePipe.transform(tommorowDate, 'yyyy-MM-dd');
    this.birthDayDate =  this.datePipe.transform(new Date(), 'yyyy-MM-dd');  }

  onSubmit(form:NgForm){
    this.addRental(form);
  }

  addRental(form: NgForm){
    this.resolveDates();
    this.service.postRental().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshAvailableCars();
        this.toastrService.success("Rental registered successfully, Cars Rental Panel")
      },
      err => {
        console.log(err);
      });
  }
  resolveDates() {
    this.service.formData.startDate = new Date(this.fromDate);
    this.service.formData.endDate = new Date(this.toDate);
    this.service.formData.customerDateOfBirth = new Date(this.birthDayDate);
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new CarRental();
  }
}
