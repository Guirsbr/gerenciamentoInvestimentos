import { Component } from '@angular/core';
import { InvestmentService } from '../services/investment.service';
import { Investment } from '../models/investment.models';
import { Observable } from 'rxjs';
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

  
}
