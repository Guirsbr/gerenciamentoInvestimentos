import { Component } from '@angular/core';
import { InvestmentService } from '../services/investment.service';
import { UserService } from '../services/user.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  title = 'home';
  
  constructor(public investmentService: InvestmentService, public userService: UserService, private readonly router: Router){
    
  }

  deleteUserInvestment(investmentId: number) : void {
    this.investmentService.deleteUserInvestmentFromApi(investmentId);
  }
}
