import { Component } from '@angular/core';
import { InvestmentService } from './services/investment.service';
import { Investment } from './models/investment.models';
import { UserService } from './services/user.service';
import { User } from './models/user.models';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontEnd';

  investment$ = new Observable<Investment[]>();
  users$ = new Observable<User[]>();
  user$ = new Observable<User>();

  constructor(public userService: UserService, private readonly router: Router){
    this.loadData();
  }

  homePage(){
    this.router.navigateByUrl("/");
  }

  loadData(){
    if (typeof localStorage == 'undefined')
      return

    let token = localStorage.getItem("token") ?? "";
    if (!token) {
      this.userService.currentUserSig.set(null)
      return
    }

    this.userService.validateUser(token)
    .subscribe((response) => {
        if (response.result) {
          this.userService.currentUserSig.set(response);
        } else {
          this.userService.currentUserSig.set(null);
        } 
    });
  }

  logout(){
    localStorage.setItem("token", "");
    this.userService.currentUserSig.set(null)
  }
}
