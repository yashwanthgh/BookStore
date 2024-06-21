import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/userservice/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  address: any;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUserAddress().subscribe((res: any) => this.address = res.data);
  }

}
