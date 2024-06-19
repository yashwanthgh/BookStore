import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/userservice/user.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {

  singinForm!: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.singinForm = this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  get signinControll() { return this.singinForm.controls; }

  handleSignin()
  {
    if(this.singinForm.invalid) {
      this.submitted = true;
      return;
    }
    const {email, password} = this.singinForm.value
    this.userService.signinCall({email:email, password:password}).subscribe(
      (res: any) => {console.log(res.data), localStorage.setItem("token", res.data); this.router.navigate(["/dashboard/book"])}, (err)=> console.log(err))
    console.log(this.signinControll)
  }

}
