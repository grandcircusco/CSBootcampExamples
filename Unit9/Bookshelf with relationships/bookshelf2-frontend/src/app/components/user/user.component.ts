import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Book from '../../interfaces/book';
import { User } from '../../interfaces/user';
import { BookService } from '../../services/book.service';
import { UserService } from '../../services/user.service';
import { BookComponent } from '../book/book.component';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [BookComponent],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  user: User = {
    username: "",
    displayName: ""
  };
  books: Book[] = [];
  borrowedBooks: Book[] = [];

  constructor(private userService: UserService, private bookService: BookService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const userId = parseInt(params['id']);
      this.userService.getUserById(userId).subscribe(user => {
        this.user = user;
      });
      this.bookService.getBooksByOwner(userId).subscribe(books => {
        this.books = books;
      });
      this.bookService.getBooksByLentTo(userId).subscribe(books => {
        this.borrowedBooks = books;
      });
    });
  }
}
