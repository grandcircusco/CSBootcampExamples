import { Routes } from '@angular/router';
import { ListOfBooksComponent } from './components/list-of-books/list-of-books.component';
import { ListOfUsersComponent } from './components/list-of-users/list-of-users.component';
import { LoginComponent } from './components/login/login.component';
import { UserComponent } from './components/user/user.component';

export const routes: Routes = [
    { path: "users", component: ListOfUsersComponent },
    { path: "users/:id", component: UserComponent },
    { path: "login", component: LoginComponent },
    { path: "", component: ListOfBooksComponent }, // the root path (homepage)
    { path: "**", redirectTo: "/" } // ** wildcard catches all
  ];
