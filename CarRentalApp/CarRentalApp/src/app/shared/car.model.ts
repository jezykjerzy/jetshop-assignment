// props must be initialized

import { Category } from "./category.model";

export class Car {
    id:number=0;
    name:string='';
    category: Category = new Category();
    totalMilageKm:number=0;
    available:number;
    kilometerPrice:number=0;


    /**
     *
     */
    constructor() {
        this.category.name='';
    }
}
