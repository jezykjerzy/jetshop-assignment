import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CarRental } from 'src/app/shared/car-rental.model';
import { CarRentalService } from 'src/app/shared/car-rental.service';
import { Car } from 'src/app/shared/car.model';

@Component({
  selector: 'app-car-rental-form',
  templateUrl: './car-rental-form.component.html',
  styleUrls: []
})
export class CarRentalFormComponent implements OnInit {

  constructor(public service:CarRentalService,
              private toastrService:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    // if(carId == 0){
    //   this.addCar(form);
    // }else{
    //   this.updateCar(form);
    // }
    this.addRental(form);
  }

    addRental(form: NgForm){
      this.service.postRental().subscribe(
        res => {
          this.resetForm(form);
          this.service.refreshAvailableCars();
          this.toastrService.success("Submitted successfully, Cars Administration Panel")
        },
        err => {
          console.log(err);
        });
    }

    resetForm(form:NgForm){
      form.form.reset();
      this.service.formData = new CarRental();
    }
}
