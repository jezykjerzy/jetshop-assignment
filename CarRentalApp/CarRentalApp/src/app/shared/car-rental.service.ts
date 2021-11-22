import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarRental } from './car-rental.model';
import { Car } from './car.model';

@Injectable({
  providedIn: 'root'
})
export class CarRentalService {

  constructor(private http : HttpClient){} 
  readonly baseUrl = "https://localhost:44394/api/carrental";

  formData:CarRental = new CarRental();
  availableCars : Car[];

  postRental(){
    return this.http.post(this.baseUrl, this.formData);
  }

  postReturn(){
    return this.http.post(`${this.baseUrl}`, this.formData);
  }

  refreshAvailableCars(){
    let url = `${this.baseUrl}/available`;
    this.http.get(url)
             .toPromise()
             .then(
               res => {
                 this.availableCars = res as Car[];             
                },
                err =>{
                  console.log(err);}
                );
  }
}
