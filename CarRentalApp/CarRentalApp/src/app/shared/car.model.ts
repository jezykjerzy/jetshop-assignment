// props must be initialized

import { Category } from "./category.model";

export class Car {
    id:number=0;
    name:string='';
    category: Category = new Category();
}
