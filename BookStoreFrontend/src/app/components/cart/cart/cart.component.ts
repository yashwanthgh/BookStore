import { CartService } from 'src/app/services/cartservice/cart.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
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
    this.cartService.getCartApi().subscribe((res: any) => {
      this.cartList = res.data.filter((item: any) => item.isUnCarted === false);
      console.log(this.cartList);
    });
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
    let price = this.cartList.reduce((total, item) => total + item.price, 0);
    this.cartService.setPrice(price);
    console.log(price);

    this.userService.getUserAddress().subscribe(
  (address: any) => {
    this.cartService.setAddress(address.data);
    console.log(address.data);
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
