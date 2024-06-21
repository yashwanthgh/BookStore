import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpService {

  baseUrl:string="https://localhost:7049/api";

  constructor(private httpClient: HttpClient) {}

  private authHeader = new HttpHeaders({
    Accept: 'application/json',
    Authorization: `Bearer ${localStorage.getItem('token')}` || '',
  });

  signinApi(data: any) {
    return this.httpClient.post('http://localhost:5277/api/login', data);
  }

  signupApi(data: any) {
    return this.httpClient.post('http://localhost:5277/api/register', data);
  }

  getBooksApi(){
    return this.httpClient.get('http://localhost:5277/api/getBooks', {headers: this.authHeader});
  }

  addToCartApi(data:any){
    return this.httpClient.post('http://localhost:5277/api/addToCart', data, {headers:this.authHeader});
  }

  getCartApi(){
    return this.httpClient.get('http://localhost:5277/api/getCartBooks', {headers:this.authHeader});
  }

  unCartApi(data: number){
    return this.httpClient.patch(`http://localhost:5277/api/uncart${data}`, {}, { headers: this.authHeader });
  }

  addAddressApi(data: any){
    return this.httpClient.post('http://localhost:5277/api/addAddress', data, { headers: this.authHeader })
  }

  getAddressApi(){
    return this.httpClient.get('http://localhost:5277/api/getAddress', { headers: this.authHeader })
  }

}
