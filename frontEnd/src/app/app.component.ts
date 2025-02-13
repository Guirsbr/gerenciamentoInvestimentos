import { Component } from '@angular/core';
import { InvestmentService } from './services/investment.service';
import { Investment } from './models/investment.models';
import { UserService } from './services/user.service';
import { User } from './models/user.models';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

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

  constructor(private investmentervice: InvestmentService, private userService: UserService){
    // this.getInvestmentsDoUser();
    // this.getUsersDoSistema();
    // this.getUserEspecifico();
  }

  getUserInvestments(){
    this.investment$ = this.investmentervice.getInvestments();
  }

  getSistemUsers(){
    this.users$ = this.userService.getUsers();
  }

  getSpecificUser(){
    this.user$ = this.userService.getUser("teste@hotmail.com", "12345");
  }

}
