import { Component, OnInit } from '@angular/core';
import { BookService } from '../services/book.service';
import { Book } from '../services/book.model';
import { Router } from '@angular/router';
import { ActivatedRoute, Params } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  inStock : any;

  constructor(private router: Router,
              private activedRoute: ActivatedRoute,
              private toastr: ToastrService,
              private bookService : BookService) { 

        this.router.routeReuseStrategy.shouldReuseRoute = function() {
          return false;
      };


  }

  ngOnInit() {    
    this.activedRoute.queryParams.subscribe(params => {
      this.inStock = params['inStock'] || false;      
    });    
    this.bookService.getBookList(this.inStock);    
  }

  showForEdit(book : Book) {
    this.router.navigate(['/manage-book']);    
  }

  onDelete(id : number){
    if (confirm('Deseja realmente apagar o registro ?') == true)
      this.bookService.deleteBook(id)
      .subscribe(x => {
        this.bookService.getBookList(this.inStock);
        this.toastr.warning('Registro excluído com sucesso', 'Book Store')
      })
  }

}
