import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Book from '../interfaces/book';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {

   // The base URL points to our Java Spring Boot backend.
  // This is set in environment.ts. It could be localhost or it could be deployed on AWS.
  baseURL: string = environment.apiBaseUrl + "/books";

  constructor(private http: HttpClient) {}

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseURL}`);
  };
  // GET /books?ownerId=...
  getBooksByOwner(ownerId: number): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseURL}`, {
      params: {ownerId: ownerId}
    });
  };
  // GET /books?lentOutToId=...
  getBooksByLentTo(lentOutToId: number): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseURL}`, {
      params: {lentOutToId: lentOutToId}
    });
  };
  searchBooks(
    ownerId: number,
    query: string,
    lentOut: boolean | null
  ): Observable<Book[]> {
    // Add URL query parameters to an object. HttpClient will add them to the URL safely.
    const params: any = { ownerId: ownerId };
    if (query) {
      params.q = query;
    }
    if (lentOut !== null) {
      params.lentOut = lentOut;
    }
    return this.http.get<Book[]>(`${this.baseURL}`, {
      params,
    });
  };
  // Get by ID is not used in this application, but it's included here as an example
  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.baseURL}/${id}`);
  }
  // Use the various HTTP methods as needed.
  // All of these still return an observable. We must subscribe in the component in
  // order to trigger the actual API call.
  updateBook(updatedBook: Book): Observable<Book> {
    // For PUT, pass the body data as a second parameter after the URL
    return this.http.put<Book>(`${this.baseURL}/${updatedBook.id}`, updatedBook);
  };
  addBook(newBook: Book): Observable<Book> {
    // For POST, pass the body data as a second parameter after the URL
    return this.http.post<Book>(`${this.baseURL}`, newBook);
  };
  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseURL}/${id}`);
  };
}
