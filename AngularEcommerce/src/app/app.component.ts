import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NgToastModule, NgToastService, ToasterPosition } from 'ng-angular-popup';
import { AsyncPipe, CommonModule } from '@angular/common';
import { filter, Observable } from 'rxjs';
import { LoginService } from './services/login/login.service';
import { Store } from '@ngrx/store';
import { AppState } from './states/app.state';
import { selectFullName, selectorLoginState, selectUser } from './states/user/user.selector';
import { ILoginState } from './states/user/user.reducer';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterLinkActive,RouterLink,NgToastModule,CommonModule,AsyncPipe],
templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  ToasterPosition = ToasterPosition;
  userIsLoggedIn: boolean = false;
  isLoginPage:boolean = false;
  fullName:string|null=null;
  loginState: Observable<ILoginState>; 
  userImage: string | undefined; 

  constructor(
    private loginService: LoginService,
    private router: Router,
    private toast: NgToastService,
    private store:Store<AppState>
  ) {
    this.loginState=this.store.select(selectUser);
  }

  ngOnInit(): void {
    // Initially set the userIsLoggedIn based on login status
    this.userIsLoggedIn = this.loginService.userIsLoggedIn();
    // Subscribe to login status changes
    this.loginService.loginStatusChange.subscribe((loggedIn: boolean) => {
      this.userIsLoggedIn = loggedIn;
    });
    this.store.select(selectUser).subscribe(user => {
      console.log('User info:', user); // Access user info from the store
    });
    this.loginState.subscribe((data) => {
      this.fullName=data.user.fullName;
      this.userImage=data.user.profilePic;
    });
  }

  logout(): void {
    this.loginService.logoutUser();
  }

  login(): void {
    this.router.navigate(['login']);
  }
}