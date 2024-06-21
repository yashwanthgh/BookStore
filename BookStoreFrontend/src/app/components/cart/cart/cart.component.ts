import { CartService } from 'src/app/services/cartservice/cart.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit, OnDestroy {
  cartList: any[] = [];
  subscription: Subscription = new Subscription();

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.cartService.getCartApi().subscribe((res: any) => {
      this.cartList = res.data.filter((item: any) => item.isUnCarted === false);
      console.log(this.cartList);
  });
  }

  handelClear(data: any){
    
    this.cartService.unCartApi(data.cartId).subscribe(() => {
      this.cartList = this.cartList.filter(item => item.cartId !== data.cartId);
    }, error => {
      console.error('Error uncataloging the item', error);
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
