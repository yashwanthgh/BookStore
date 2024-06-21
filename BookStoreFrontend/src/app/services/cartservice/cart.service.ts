import { Injectable } from '@angular/core';
import { HttpService } from '../httpservice/http.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  totalPrice: any;
  address: any;

  constructor(private httpService:HttpService) { }

  getCartApi(){
    return this.httpService.getCartApi();
  }
  
  addToCartApi(data:any){
    return this.httpService.addToCartApi(data);
  }

  unCartApi(data: any){
    return this.httpService.unCartApi(data);
  }

  getPrice(){
    return this.totalPrice;
  }

  setPrice(data: any){
    this.totalPrice = data;
  }

  getAddress(){
    return this.address;
  }

  setAddress(data: any){
    this.address = data;
  }
}
