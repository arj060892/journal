import { User } from './../models/user';
import { SignUp } from './../models/signup';
import { Login } from './../models/login';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  readonly REQUESTURL = 'https://localhost:7212/user';

  public userDetails = new Subject<User>();
  userToken: string | undefined;

  constructor(private httpClient: HttpClient) {}

  login(loginDetails: Login) {
    return this.httpClient
      .post(this.REQUESTURL + '/login', { loginDetails })
      .pipe(tap((userDetail: any) => this.userDetails.next(userDetail)));
  }

  signUp(signUpDetails: SignUp) {
    return this.httpClient
      .post(this.REQUESTURL + '/signup', signUpDetails)
      .pipe(tap((userDetail: any) => this.userDetails.next(userDetail)));
  }

  logout() {
    this.userToken = undefined;
  }

  isUserLoggedIn() {
    return !!this.userToken;
  }
}
