import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CarRentalService } from 'src/app/shared/car-rental.service';
import { Car } from 'src/app/shared/car.model';
import { Category } from 'src/app/shared/category.model';

@Component({
  selector: 'app-car-detail-form',
  templateUrl: './car-detail-form.component.html',
  styles: [
  ]
})
export class CarDetailFormComponent implements OnInit {

  constructor(public service:CarRentalService,
              private toastrService:ToastrService) { }

  ngOnInit(): void {
  }

  carCategories: Category[];

  onSubmit(form:NgForm){
    let carId = this.service.formData.id;
    let category = this.service.formData.category;
    if(carId == 0){
      this.addCar(form);
    }else{
      this.updateCar(form);
    }
  }

  updateCar(form: NgForm) {
    this.service.putCar().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshCars();
        this.toastrService.info("Updated successfully, Cars Administration Panel")
      },
      err => {
        console.log(err);
      }
    )
  }
  addCar(form: NgForm) {
    this.service.postCar().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshCars();
        this.toastrService.success("Submitted successfully, Cars Administration Panel")
      },
      err => {
        console.log(err);
      }
    )
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new Car();
  }

}
