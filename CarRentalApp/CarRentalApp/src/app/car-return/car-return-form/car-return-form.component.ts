import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CarRental } from 'src/app/shared/car-rental.model';
import { CarRentalService } from 'src/app/shared/car-rental.service';
import { CarReturn } from 'src/app/shared/car-return.model';
import { CarReturnService } from 'src/app/shared/car-return.service';

@Component({
  selector: 'app-car-return-form',
  templateUrl: './car-return-form.component.html',
  styleUrls: []
})
export class CarReturnFormComponent implements OnInit {

  constructor(public service: CarReturnService,
    private toastrService: ToastrService,
    private datePipe: DatePipe) { }

  fromDate: any;
  returnDate: any;
  birthDayDate: any;

  ngOnInit(): void {
    // TODO init formData with first available car properly
    let emptyRental = new CarRental();
    this.service.formData.carRental = emptyRental;
    this.setDefaultDates();
  }
  // TODO Introduce string model for user input

  setDefaultDates() {
    this.fromDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.returnDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.birthDayDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
  }

  onSubmit(form: NgForm) {
    this.addReturn(form);
  }

  addReturn(form: NgForm){
    this.resolveDates();
    this.service.formData.currentCarMilageKm = Number(this.service.formData.currentCarMilageKm);
    this.service.postReturn().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshAvailableRentals();
        console.log(JSON.stringify(res));
        let data = JSON.parse(JSON.stringify(res));
      
        this.toastrService.success(`Return registered successfully. Price is ${data.price}`, 'Cars Rental Panel');
      },
      err => {
        console.log(err);
      });
  }

  resolveDates() {
    this.service.formData.returnDate = new Date(this.returnDate);
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new CarReturn();
  }

}
