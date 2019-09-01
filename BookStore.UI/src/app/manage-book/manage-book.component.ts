import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { BookService } from '../services/book.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthorService } from '../services/author.service';

@Component({
  selector: 'app-manage-book',
  templateUrl: './manage-book.component.html',
  styleUrls: ['./manage-book.component.css']
})
export class ManageBookComponent implements OnInit {

  id : number;    

  constructor(private router: Router, 
              private activedRoute: ActivatedRoute,
              private bookService: BookService,
              private authorService: AuthorService,
              private toastr: ToastrService) { }

  ngOnInit() {
    this.activedRoute.params.subscribe(params => {
      this.id = params['id'];      
    });    

    this.resetForm();

    if (this.id){        
      this.bookService.getBook(this.id);      
    }
  }

  resetForm(form?: NgForm){            

    if (form != null)
      form.reset();

    this.bookService.selectedBook = {
      Id: null,
      Title: '',
      StockQty: null,
      Author: { Id: null, Name: '' },
      AuthorId: null
    }

    this.authorService.getAuthorList();    
  }

  onSubmit(form : NgForm){      
    if (form.value.Id == null){
      this.bookService.postBook(form.value)
      .subscribe(data => {                 
        this.resetForm(form);
        this.toastr.success('Registro incluído com sucesso', 'Book Store');
        this.router.navigate(['/home']);
      })
    }
    else{
      this.bookService.putBook(form.value.Id, form.value)
      .subscribe(data => {                   
        this.resetForm(form);
        this.toastr.info('Registro alterado com sucesso', 'Book Store');
        this.router.navigate(['/home']);
      })
      
    }
  }

}
