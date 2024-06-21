import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartService } from 'src/app/services/cartservice/cart.service';
import { HttpService } from 'src/app/services/httpservice/http.service';
import { HEART_ICON, STAR_ICON } from 'src/assets/svg-icons';

@Component({
  selector: 'app-bookdetails',
  templateUrl: './bookdetails.component.html',
  styleUrls: ['./bookdetails.component.scss'],
})
export class BookdetailsComponent implements OnInit, OnDestroy {
  cartForm!: FormGroup;
  subscription: Subscription = new Subscription();
  selectBook: any;
  bookData: any;
  bookId!: number;
  

  constructor(
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    private httpService: HttpService,
    private route: ActivatedRoute,
    private cartService: CartService,
    private formBuilder: FormBuilder
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
        console.log(this.selectBook);
      });
    });
  }

  handleAddBook(data: any) {

    this.cartForm = this.formBuilder.group({
      quantity: [1],  
      bookId: data.bookId,   
      isOrdered: [false], 
      isUnCarted: [false]  
    });

    const { quantity, bookId, isOrdered, isUnCarted } = this.cartForm.value;

    const cartItem = {
      quantity: quantity,
      bookId: bookId,
      isOrdered: isOrdered,
      isUnCarted: isUnCarted
    };

    this.cartService.addToCartApi(cartItem).subscribe(
      (res) => console.log('Added to cart:', res),
      (err) => console.error('Error adding to cart:', err)
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
