import { HttpClient } from '@angular/common/http';
import { Injectable, ɵɵsetComponentScope } from '@angular/core';
import { Car } from './car.model';
import { Category } from './category.model';

@Injectable({
  providedIn: 'root'
})
export class CarRentalService {

  constructor(private http : HttpClient) { }
  readonly baseUrl = "https://localhost:44394/api/cars";
  
  formData:Car = new Car();
  cars : Car[];
  categories: Category[];

  postCar(){
    return this.http.post(this.baseUrl, this.formData);
  }

  putCar(){
    const url = `${this.baseUrl}/${this.formData.id}`;
    return this.http.put(url, this.formData)
  }

  deleteCar(carId: number){
    const url = `${this.baseUrl}/${carId}`;
    return this.http.delete(url);
  }

  refreshCars(){
    this.http.get(this.baseUrl)
             .toPromise()
             .then(
               res => {
                 this.cars = res as Car[];             
                },
                err =>{
                  console.log(err);}
                );

    this.http.get(`${this.baseUrl}/categories`)
             .toPromise()
             .then(
               res => {
                 this.categories = res as Category[];
               },
               err =>{
                console.log(err);}
               );
  }
}
