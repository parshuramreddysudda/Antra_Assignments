import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NgToastModule, NgToastService, ToasterPosition } from 'ng-angular-popup';
import { CommonModule } from '@angular/common';
import { filter } from 'rxjs';
import { LoginService } from './services/login/login.service';
import { Store } from '@ngrx/store';
import { LoginResponse } from './components/types/login';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterLinkActive,RouterLink,NgToastModule,CommonModule],
templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  constructor(
    private loginService: LoginService,
    private router: Router,
    private toast: NgToastService
  ) {}

  ToasterPosition = ToasterPosition;
  userIsLoggedIn: boolean = false;
  isLoginPage:boolean = false;
  userName = 'John Doe'; // This should be dynamic
  userImage = 'https://via.placeholder.com/40'; // This should be dynamic

  ngOnInit(): void {
    // Initially set the userIsLoggedIn based on login status
    this.userIsLoggedIn = this.loginService.userIsLoggedIn();
    // Subscribe to login status changes
    this.loginService.loginStatusChange.subscribe((loggedIn: boolean) => {
      this.userIsLoggedIn = loggedIn;
    });
    this.router.events
    .pipe(filter((event): event is NavigationEnd => event instanceof NavigationEnd))
    .subscribe((event: NavigationEnd) => {
      this.isLoginPage = event.url === '/login';
    });
  }

  logout(): void {
    this.loginService.logoutUser();
  }

  login(): void {
    this.router.navigate(['login']);
  }
}