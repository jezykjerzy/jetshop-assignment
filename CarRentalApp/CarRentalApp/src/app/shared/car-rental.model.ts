import { Car } from "./car.model";

export class CarRental {
    id:number=0;
    car:Car = new Car();
    startDate: Date =new Date();
    endDate: Date =new Date();
    providedUserEndDate: Date =new Date();
    customerDateOfBirth:Date = new Date();
    currentCarMilageKm:number =0;
    constructor(){
       this.car.category.name=''; 
    }
}
