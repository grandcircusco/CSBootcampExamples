import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  // The base URL points to our Java Spring Boot backend.
  // This is set in environment.ts. It could be localhost or it could be deployed on AWS.
  baseURL: string = environment.apiBaseUrl + "/users";

  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseURL}`);
  };
  getUsersByUsername(username: string): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseURL}`, {
      params: { username: username }
    })
  }
  // Get by ID is not used in this application, but it's included here as an example
  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.baseURL}/${id}`);
  }
  // Use the various HTTP methods as needed.
  // All of these still return an observable. We must subscribe in the component in
  // order to trigger the actual API call.
  updateUser(updatedUser: User): Observable<User> {
    // For PUT, pass the body data as a second parameter after the URL
    return this.http.put<User>(`${this.baseURL}/${updatedUser.id}`, updatedUser);
  };
  addUser(newUser: User): Observable<User> {
    // For POST, pass the body data as a second parameter after the URL
    return this.http.post<User>(`${this.baseURL}`, newUser);
  };
  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseURL}/${id}`);
  };
}
