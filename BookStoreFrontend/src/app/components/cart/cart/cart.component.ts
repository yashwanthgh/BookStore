import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { CartService } from 'src/app/services/cartservice/cart.service';
import { UserService } from 'src/app/services/userservice/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit, OnDestroy {
  cartList: any[] = [];
  subscription: Subscription = new Subscription();

  constructor(
    private cartService: CartService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.subscription.add(
      this.cartService.getCartApi().subscribe((res: any) => {
        this.cartList = res.data
          .filter((item: any) => item.isUnCarted === false)
          .map((item: any) => ({
            ...item,
            quantity: item.quantity || 1, 
          }));
        console.log(this.cartList);
      })
    );
  }

  incrementQuantity(book: any) {
    book.quantity++;
  }

  decrementQuantity(book: any) {
    if (book.quantity > 1) {
      book.quantity--;
    }
  }

  handelClear(data: any) {
    this.cartService.unCartApi(data.cartId).subscribe(
      () => {
        this.cartList = this.cartList.filter(
          (item) => item.cartId !== data.cartId
        );
      },
      (error) => {
        console.error('Error uncataloging the item', error);
      }
    );
  }

  handelPlaceOrder() {
    const totalPrice = this.cartList.reduce(
      (total, item) => total + item.price * item.quantity, 
      0
    );
    this.cartService.setPrice(totalPrice);
    console.log('Total price:', totalPrice);

    this.userService.getUserAddress().subscribe(
      (address: any) => {
        this.cartService.setAddress(address.data);
        console.log('Address data:', address.data);
      },
      (error) => {
        console.error('Error fetching address:', error);
      }
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
