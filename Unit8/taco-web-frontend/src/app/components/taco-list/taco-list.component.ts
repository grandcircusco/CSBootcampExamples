import { Component } from '@angular/core';
import { TacoApiService } from '../../services/taco-api.service';
import { Taco } from '../../interfaces/taco';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-taco-list',
  standalone: true,
  imports: [ CurrencyPipe ],
  templateUrl: './taco-list.component.html',
  styleUrl: './taco-list.component.css'
})
export class TacoListComponent {

  tacos:Taco[] = [];

  constructor(private tacoApiService:TacoApiService){}

  ngOnInit() {
    this.tacoApiService.getAllTacos().subscribe((response) => {
      console.log("Tacos response:", response); //Optional, but helps with debugging
      this.tacos = response;
   });
  }

}
