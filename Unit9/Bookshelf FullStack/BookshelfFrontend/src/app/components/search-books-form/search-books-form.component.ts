import { Component, EventEmitter, Output } from '@angular/core';
import { SearchParams } from '../../interfaces/search-params';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-books-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './search-books-form.component.html',
  styleUrl: './search-books-form.component.css'
})
export class SearchBooksFormComponent {
  @Output() searchBookshelf = new EventEmitter<SearchParams>();

  query: string = "";
  lentOut: string = "null";

  constructor() {}

  ngOnInit(): void {}

  search = (): void => {
    // lentOut is a string and we have to convert it to boolean | null
    let status: boolean | null;
    if (this.lentOut === "true") {
      status = true;
    } else if (this.lentOut === "false") {
      status = false;
    } else {
      status = null;
    }

    this.searchBookshelf.emit({ query: this.query, lentOut: status });
  };

  clear = (): void => {
    this.query = "";
    this.lentOut = "null";
  };
}
