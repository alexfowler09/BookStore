import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';

import { HomeComponent }  from './home/home.component';
import { ManageBookComponent }  from './manage-book/manage-book.component';

const routes: Routes = [
    { path: 'home', component: HomeComponent },    
    { path: 'manage-book', component: ManageBookComponent },
    { path: 'manage-book/:id', component: ManageBookComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
})

export class AppRoutingModule{ }