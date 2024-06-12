import { Routes } from '@angular/router';
import { TacoListComponent } from './components/taco-list/taco-list.component';
import { DrinkListComponent } from './components/drink-list/drink-list.component';
import { ComboListComponent } from './components/combo-list/combo-list.component';

export const routes: Routes = [
  { path: "tacos", component: TacoListComponent },
  { path: "drinks", component: DrinkListComponent },
  { path: "combos", component: ComboListComponent },
  { path: "", pathMatch: "full", redirectTo: "tacos" }
];
