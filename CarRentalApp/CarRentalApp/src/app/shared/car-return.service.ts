import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarRental } from './car-rental.model';
import { CarReturn } from './car-return.model';

@Injectable({
  providedIn: 'root'
})
export class CarReturnService {

  constructor(private http : HttpClient) { }
  readonly baseUrl = "https://localhost:44394/api/carrental";

  
  formData:CarReturn = new CarReturn();
  availableRentals : CarRental[];

  postReturn(){
    return this.http.post(`${this.baseUrl}/return`, this.formData);
  }

  refreshAvailableRentals(){
    let url = `${this.baseUrl}/availablerentals`;
    this.http.get(url)
             .toPromise()
             .then(
               res => {
                 this.availableRentals = res as CarRental[];             
                },
                err =>{
                  console.log(err);}
                );
  }

}
