import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './components/signup/signup.component';
import { SigninComponent } from './components/signin/signin.component';
import { HeaderComponent } from './components/header/header.component';
import { BookcontainerComponent } from './components/bookcontainer/bookcontainer/bookcontainer.component';
import { BookComponent } from './components/book/book/book.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BookdetailsComponent } from './components/bookdetails/bookdetails/bookdetails.component';

const routes: Routes = [
  { path: 'signup', component: SignupComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'header', component: HeaderComponent },
  { path: 'bookcnt', component: BookcontainerComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: [
      { path: 'book', component: BookComponent },
      { path: 'bookdetails/:bookId', component: BookdetailsComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
