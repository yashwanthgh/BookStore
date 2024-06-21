import { Injectable } from '@angular/core';
import { HttpService } from '../httpservice/http.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpService: HttpService) { }

  signinCall(data:any){
    return this.httpService.signinApi(data);
  }

  signupCall(data:any){
    return this.httpService.signupApi(data);
  }

  addUserAddress(data: any){
    return this.httpService.addAddressApi(data);
  }

  getUserAddress(){
    return this.httpService.getAddressApi();
  }
}
