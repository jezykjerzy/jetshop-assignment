import { CarRental } from "./car-rental.model";

export class CarReturn {
    id:number=0;
    carRental:CarRental = new CarRental();
    returnDate:Date = new Date();
    currentCarMilageKm: number=0;
}
