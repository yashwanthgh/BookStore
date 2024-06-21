import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/userservice/user.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {

  address: any;

  constructor(private userService: UserService, ) { }

  ngOnInit(): void {
    this.userService.getUserAddress().subscribe((res: any) => this.address = res.data);
  }

}
