import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/services/cartservice/cart.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  address: any;
  totalPrice: any;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.address = this.cartService.getAddress();
    this.totalPrice = this.cartService.getPrice();
  }

}
