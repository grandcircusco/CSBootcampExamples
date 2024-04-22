import { Component, EventEmitter, Output } from '@angular/core';
import Book from '../../interfaces/book';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-book-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-book-form.component.html',
  styleUrl: './add-book-form.component.css'
})
export class AddBookFormComponent {
  @Output() addBookToShelf = new EventEmitter<Book>();

  title: string = "";
  author: string = "";
  pages: string = "";

  constructor(private authService: AuthService) {}

  ngOnInit(): void {}

  add = (): void => {
    const ownerId = this.authService.getLoggedInUserId();
    if (ownerId === null) {
      alert("Must be logged in to add a book.");
      return;
    }

    this.addBookToShelf.emit({
      title: this.title,
      author: this.author,
      pages: parseInt(this.pages),
      lentOut: false,
      ownerId: ownerId,
      lentOutTo: null
    });
    this.title = "";
    this.author = "";
    this.pages = "";
  };
}
