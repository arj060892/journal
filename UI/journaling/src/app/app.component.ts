import { User } from './models/user';
import { UserService } from './services/user.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  userDetail: User | undefined;
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    this.userService.userDetails.subscribe((user) => (this.userDetail = user));
  }

  logout() {
    this.logout();
    this.router.navigate(['']);
  }
}
