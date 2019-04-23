import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ManageBookComponent } from './manage-book/manage-book.component';
import { BookService } from './services/book.service';
import { AppRoutingModule }  from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthorService } from './services/author.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ManageBookComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,       
    BrowserAnimationsModule, 
    ToastrModule.forRoot()
  ],
  providers: [ BookService, AuthorService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
