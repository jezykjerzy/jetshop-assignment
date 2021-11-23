import { Car } from "./car.model";

export class CarRental {
    id:number=0;
    car:Car = new Car();
    customerDateOfBirth:Date = new Date();
    startDate: Date =new Date();
    endDate:Date = new Date();
}
