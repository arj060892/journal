import { SignUp } from './../models/signup';
import { Login } from './../models/login';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-authentication',
  templateUrl: './user-authentication.component.html',
  styleUrls: ['./user-authentication.component.scss'],
})
export class UserAuthenticationComponent {
  loginDetails!: Login;
  signUpDetails!: SignUp;
  constructor(private userService: UserService) {
    this.loginDetails = { email: '', password: '' };
    this.signUpDetails = {
      email: '',
      firstName: '',
      lastName: '',
      password: '',
    };
  }

  login() {
    this.userService.login(this.loginDetails).subscribe((user) => {
      console.log(user);
    });
  }

  signUp() {
    this.userService.signUp(this.signUpDetails).subscribe((user) => {
      console.log(user);
    });
  }
}
