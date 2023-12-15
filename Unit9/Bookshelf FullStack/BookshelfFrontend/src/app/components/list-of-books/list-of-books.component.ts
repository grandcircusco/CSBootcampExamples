import { Component } from '@angular/core';
import { Book } from '../../interfaces/book';
import { SearchParams } from '../../interfaces/search-params';
import { BookshelfService } from '../../services/bookshelf.service';
import { BookComponent } from '../book/book.component';
import { SearchBooksFormComponent } from '../search-books-form/search-books-form.component';
import { AddBookFormComponent } from '../add-book-form/add-book-form.component';

@Component({
  selector: 'app-list-of-books',
  standalone: true,
  imports: [BookComponent, SearchBooksFormComponent, AddBookFormComponent],
  templateUrl: './list-of-books.component.html',
  styleUrl: './list-of-books.component.css'
})
export class ListOfBooksComponent {
  books: Book[] = [];
  filters: SearchParams = { query: "", lentOut: null}
  constructor(private bookshelfService: BookshelfService) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    if (this.hasFilters()) {
      this.bookshelfService
      .searchBooks(this.filters.query, this.filters.lentOut)
      .subscribe((data: Book[]) => {
        this.books = data;
      });
    } else {
      this.bookshelfService.getAllBooks().subscribe((data: Book[]) => {
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

  updateLentOut(book: Book): void {
    const updatedBook = { ...book };
    updatedBook.lentOut = !book.lentOut;
    this.bookshelfService
      .updateBook(updatedBook)
      .subscribe(() => this.loadBooks());
  };

  addBookToShelf(book: Book): void {
    this.bookshelfService.addBook(book).subscribe(() => this.loadBooks());
  };

  removeBookFromShelf(id: number): void {
    this.bookshelfService.deleteBook(id).subscribe(() => this.loadBooks());
  };
}
