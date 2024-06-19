import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor() {}

  private allbooks = new BehaviorSubject<any[]>([]);
  allBookState = this.allbooks.asObservable();
  changeAllBookList(value: any[]) {
    this.allbooks.next(value);
  }

  private tempCart = new BehaviorSubject<any>({});
  tempCartState = this.tempCart.asObservable();
  tempList: any[] = [];

  changeTempCart(value: any) {
    this.modifyCart(value);
  }

  modifyCart(value: any[]) {
    this.tempList = [...this.tempList].flat();

    console.log(value);

    for (const val of value) {
      const existingItem = this.tempList.find(
        (item: any) => item.bookId === val.bookId
      );

      if (existingItem === undefined) {
        this.tempList.push(val);
      } else {
        this.tempList = this.tempList.map((item: any) => {
          if (item.bookId === val.bookId) {
            return val;
          } else {
            return item;
          }
        });
      }
    }
    this.tempCart.next(this.tempList);
  }
}
