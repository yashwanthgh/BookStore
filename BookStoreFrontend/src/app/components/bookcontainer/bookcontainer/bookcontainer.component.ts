import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/dataservice/data.service';

@Component({
  selector: 'app-bookcontainer',
  templateUrl: './bookcontainer.component.html',
  styleUrls: ['./bookcontainer.component.scss'],
})
export class BookcontainerComponent implements OnInit {

  @Input() booksData: any[] = [];

  bookList: any;
  constructor(
    private router: Router,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.dataService.allBookState.subscribe((res) => (this.booksData = res));
  }

  handleClick(data: any) {
    console.log(data.bookId);
    this.router.navigate([`/dashboard/bookdetails`, data.bookId]);
  }
}
