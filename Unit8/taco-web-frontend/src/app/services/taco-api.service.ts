import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Taco } from '../interfaces/taco';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TacoApiService {

  // Adjust this as needed.
  baseUrl: string = "https://localhost:7297/api/Tacos";
  // apiKey is only needed if you did the extended challenge
  apiKey: string = "abcdefghij";

  constructor(private http: HttpClient) { }

  getAllTacos(): Observable<Taco[]> {
    return this.http.get<Taco[]>(`${this.baseUrl}?apiKey=${this.apiKey}`);
  }

}
