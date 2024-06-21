import { Injectable } from '@angular/core';
import { HttpService } from '../httpservice/http.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

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
}
