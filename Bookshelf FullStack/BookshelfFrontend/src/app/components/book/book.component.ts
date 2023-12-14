import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Book } from '../../interfaces/book';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  @Input() book: Book | undefined;
  @Output() toggleLentOut = new EventEmitter<Book>();
  @Output() removeBookFromShelf = new EventEmitter<number>();

  constructor() {}

  ngOnInit(): void {}

  updateBook = (): void => {
    this.toggleLentOut.emit(this.book);
  };

  remove = (): void => {
    this.removeBookFromShelf.emit(this.book?.id);
  };
}
