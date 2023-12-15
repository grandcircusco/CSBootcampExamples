import { Component, EventEmitter, Output } from '@angular/core';
import { Book } from '../../interfaces/book';
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

  constructor() {}

  ngOnInit(): void {}

  add = (): void => {
    this.addBookToShelf.emit({
      title: this.title,
      author: this.author,
      pages: parseInt(this.pages),
      lentOut: false,
    });
    this.title = "";
    this.author = "";
    this.pages = "";
  };
}
