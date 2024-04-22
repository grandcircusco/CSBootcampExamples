import { Component } from '@angular/core';
import { Router } from '@angular/router';
import Book from '../../interfaces/book';
import SearchParams from '../../interfaces/search-params';
import { AuthService } from '../../services/auth.service';
import { BookService } from '../../services/book.service';
import { SearchBooksFormComponent } from '../search-books-form/search-books-form.component';
import { AddBookFormComponent } from '../add-book-form/add-book-form.component';
import { BookComponent } from '../book/book.component';

@Component({
  selector: 'app-list-of-books',
  standalone: true,
  imports: [SearchBooksFormComponent, AddBookFormComponent, BookComponent],
  templateUrl: './list-of-books.component.html',
  styleUrl: './list-of-books.component.css'
})
export class ListOfBooksComponent {
  books: Book[] = [];
  filters: SearchParams = { query: "", lentOut: null}
  constructor(private bookService: BookService, private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    if (this.authService.getLoggedInUserId() === null) {
      this.router.navigateByUrl("/login");
    }
    this.loadBooks();
  }

  loadBooks(): void {
    if (this.hasFilters()) {
      this.bookService
      .searchBooks(this.authService.getLoggedInUserId()!, this.filters.query, this.filters.lentOut)
      .subscribe((data: Book[]) => {
        this.books = data;
      });
    } else {
      this.bookService.getBooksByOwner(this.authService.getLoggedInUserId()!).subscribe((data: Book[]) => {
        this.books = data;
      });
    }
  };

  hasFilters(): boolean {
    return this.filters.query !== "" || this.filters.lentOut !== null;
  }

  setFilters(params: SearchParams) {
    this.filters = params;
    this.loadBooks();
  }

  clearFilters(): void {
    this.setFilters({
      query: "",
      lentOut: null
    });
  }

  updateLentOut(updatedBook: Book): void {
     this.bookService
      .updateBook(updatedBook)
      .subscribe(() => this.loadBooks());
  };

  addBookToShelf(book: Book): void {
    this.bookService.addBook(book).subscribe(() => this.loadBooks());
  };

  removeBookFromShelf(id: number): void {
    this.bookService.deleteBook(id).subscribe(() => this.loadBooks());
  };
}
