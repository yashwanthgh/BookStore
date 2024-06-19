import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/bookservice/book.service';
import { DataService } from 'src/app/services/dataservice/data.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
})
export class BookComponent implements OnInit {
  bookList: any[] = [];

  constructor(
    private bookService: BookService,
    private dataService: DataService
  ) {}

  ngOnInit() {
    this.bookService.getBooksCall().subscribe(
      (res: any) => {
        this.bookList = res.data;
        // this.dataService.changeAllBookList(res.data);
      },
      (err) => console.log("error: ",err)
    );
  }
}
