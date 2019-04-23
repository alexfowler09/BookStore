import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Author } from './author.model';

@Injectable()
export class AuthorService {

  selectedAuthor : Author;
  authorList: Author[];
  apiUrl: string;
  constructor(private http : Http) { 
    this.apiUrl = 'http://localhost:64861/author/';     
  }

  handleError(error: Response){        
    alert(error);    
    return Observable.throw(error.statusText);
  }

  getAuthorList(){        
    var url = (this.apiUrl)    
    this.http.get(url)
    .map((data: Response) => {
      return data.json() as Author[];
    }).toPromise().then(x => {
      this.authorList = x;
    })
  }

  getAuthor(id : number){
    this.http.get(this.apiUrl + id)
    .map((data: Response) => {
      return data.json() as Author;
    }).toPromise().then(x => {
      this.selectedAuthor = x;      
    })    
  }

}
