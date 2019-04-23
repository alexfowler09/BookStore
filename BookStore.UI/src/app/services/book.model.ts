import { Author } from "./author.model";

export class Book {
    Id : string;
    Title : string;
    StockQty : number;   
    Author: Author;
    AuthorId: number; 
}
