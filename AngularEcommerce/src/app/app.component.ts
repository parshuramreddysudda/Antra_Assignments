import { Component, HostListener, OnInit, signal } from '@angular/core';
import {  Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NgToastModule, ToasterPosition } from 'ng-angular-popup';
import { AsyncPipe, CommonModule } from '@angular/common';
import {  map, Observable, of } from 'rxjs';
import { LoginService } from './services/login/login.service';
import { Store } from '@ngrx/store';
import { AppState } from './states/app.state';
import { selectUser } from './states/user/user.selector';
import { ILoginState } from './states/user/user.reducer';
import { selectorCartSize } from './states/cart/cart.selector';
import { DashboardComponent } from './components/dashboard/dashboard.component';

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
  fullName:string|undefined;
  loginState: Observable<ILoginState>; 
  userImage: string | undefined; 
  role:string | undefined;
  cartItemCount:number=0;
  storeData :any;
  loggedUser:any;

  constructor(
    private loginService: LoginService,
    private router: Router,
    private store:Store<AppState>
  ) {
    this.loginState=this.store.select(selectUser);
  }

  @HostListener('window:beforeunload', ['$event'])
    beforeunloadHandler(event: Event): void {
      this.store.subscribe((data)=>{
        this.storeData=data
      })
    console.log("Reload Event Logged", this.storeData);
    localStorage.setItem('applicationState', JSON.stringify(this.storeData));
  }

  ngOnInit(): void {
    this.loggedUser= signal("Not Logged In ");

    // Initially set the userIsLoggedIn based on login status
    this.userIsLoggedIn = this.loginService.userIsLoggedIn();
    this.store.select(selectorCartSize).subscribe((size)=>{
      this.cartItemCount=size;
    })
    // Subscribe to login status changes
    this.loginService.loginStatusChange.subscribe((loggedIn: boolean) => {
      this.userIsLoggedIn = loggedIn;
    });
    this.store.select(selectUser).subscribe(user => {
      console.log('User info:', user); // Access user info from the store
    });
    this.loginState.subscribe((data) => {
      this.fullName=data?.user?.fullName;
      this.userImage=data?.user?.profilePic;
      this.role = data?.user?.role;
    });
    console.log("Current role is "+this.role);
  }


  logout(): void {
    this.loginService.logoutUser();
  }

  login(): void {
    this.router.navigate(['login']);
  }
}