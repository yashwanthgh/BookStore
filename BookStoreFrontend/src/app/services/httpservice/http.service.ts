import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
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
}
