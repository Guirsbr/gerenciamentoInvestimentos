import { Component } from '@angular/core';
import { UserService } from './services/user.service';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { InvestmentService } from './services/investment.service';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontEnd';

  
  current_year: number = new Date().getFullYear();

  constructor(public authService: AuthService, public investmentService: InvestmentService, public userService: UserService, private readonly router: Router){
    this.automaticLogin();
  }

  navigateHomePage(){
    if (this.userService.currentUserSig()){
      this.router.navigateByUrl("/");
    } else {
      this.router.navigateByUrl("/login");
    }  
  }

  logout(){
    localStorage.setItem("token", "");
    this.userService.currentUserSig.set(null)
    this.router.navigateByUrl("/login");
  }

  automaticLogin(){
    if (typeof localStorage == 'undefined'){
      this.userService.currentUserSig.set(null)
      this.router.navigateByUrl("/login");
      return
    }
      
    let token = localStorage.getItem("token") ?? "";
    if (!token) {
      this.userService.currentUserSig.set(null)
      this.router.navigateByUrl("/login");
      return
    }

    this.authService.validateUser(token)
    .subscribe((response) => {
        if (response.result) {
          this.userService.currentUserSig.set(response);
          this.router.navigateByUrl("/");
          this.investmentService.getUserInvestments(token);
        } else {
          this.userService.currentUserSig.set(null);
          localStorage.setItem("token", "");
          this.router.navigateByUrl("/login");
        } 
    });
  }

}
