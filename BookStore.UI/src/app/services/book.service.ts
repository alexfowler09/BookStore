import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Book } from './book.model';

@Injectable()
export class BookService {

  selectedBook : Book;
  bookList: Book[];
  apiUrl: string;
  constructor(private http : Http) { 
    this.apiUrl = 'http://localhost:64861/book/'; 
  }

  postBook(book : Book) {
    var data = JSON.stringify(book);
    var headerOptions = new Headers({'Content-Type': 'application/json'});
    var requestOptions = new RequestOptions({method: RequestMethod.Post, headers: headerOptions});
    return this.http.post(this.apiUrl, data, requestOptions).map(x => x.json()).catch(this.handleError);
  }

  putBook(id : number, book : Book) {
    var data = JSON.stringify(book);
    var headerOptions = new Headers({'Content-Type': 'application/json'});
    var requestOptions = new RequestOptions({method: RequestMethod.Put, headers: headerOptions});
    return this.http.put(this.apiUrl + id, data, requestOptions).map(x => x.json()).catch(this.handleError);    
  }

  handleError(error: Response){        
    alert(error);    
    return Observable.throw(error.statusText);
  }

  getBookList(inStock : boolean){
    var url = (inStock ? this.apiUrl + '/instock' : this.apiUrl )    
    var url = (url)    
    this.http.get(url)
    .map((data: Response) => {
      return data.json() as Book[];
    }).toPromise().then(x => {
      this.bookList = x;
    })
  }

  getBook(id : number){
    this.http.get(this.apiUrl + id)
    .map((data: Response) => {
      return data.json() as Book;
    }).toPromise().then(x => {
      this.selectedBook = x;      
    })    
  }
  
  deleteBook(id: number){
    return this.http.delete(this.apiUrl + id).map(res => res.json());
  }  

}
