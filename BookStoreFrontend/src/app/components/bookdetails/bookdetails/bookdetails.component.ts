import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/dataservice/data.service';
import { HttpService } from 'src/app/services/httpservice/http.service';
import { HEART_ICON, STAR_ICON } from 'src/assets/svg-icons';

@Component({
  selector: 'app-bookdetails',
  templateUrl: './bookdetails.component.html',
  styleUrls: ['./bookdetails.component.scss'],
})
export class BookdetailsComponent implements OnInit, OnDestroy {
  subscription: Subscription = new Subscription();
  selectBook: any;
  bookData: any;
  bookId!: number;
  count: number = 1;
  bookCount: boolean = false;
  cartId!: number;
  tempcart: any[] = [];

  constructor(
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    private router: Router,
    private httpService: HttpService,
    private route: ActivatedRoute,
    private dataService: DataService
  ) {
    iconRegistry.addSvgIconLiteral(
      'heart-icon',
      sanitizer.bypassSecurityTrustHtml(HEART_ICON)
    );
    iconRegistry.addSvgIconLiteral(
      'star-icon',
      sanitizer.bypassSecurityTrustHtml(STAR_ICON)
    );
  }

  ngOnInit(): void {
    this.httpService.getBooksApi().subscribe((res1: any) => {
      this.bookData = res1.data;
  
      this.route.params.subscribe((res2) => {
        this.selectBook = this.bookData.find((e: any) => e.bookId == res2['bookId']);
      });
    });
  }

  handleAddBook(data: any) {

    this.bookCount = !this.bookCount;

    var tempdata = [];
    tempdata[tempdata.length] = data;
    this.dataService.changeTempCart(tempdata);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
