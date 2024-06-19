import { UserService } from './../../services/userservice/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signupForm!: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber:['', [Validators.required,Validators.minLength(10)]],
      confirmpassword:['', [Validators.required, Validators.minLength(6)]]}
    );
  }

  get signupControll() { return this.signupForm.controls; }

  handleSignup(){
    console.log(this.signupForm.controls);
    const{name,email,phoneNumber,password}=this.signupForm.value;
    this.userService.signupCall({
      name: name,
      email: email,
      phoneNumber: phoneNumber,
      password: password
    }).subscribe((res)=>console.log(res),
    (err)=>console.log(err))
  }

}
