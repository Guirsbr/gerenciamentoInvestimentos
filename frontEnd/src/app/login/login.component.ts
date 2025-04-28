import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginRequest } from '../models/loginRequest.models';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { InvestmentService } from '../services/investment.service';


@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  title = 'login';

  form = new FormGroup({
    email: new FormControl("", Validators.required),
    password: new FormControl("", Validators.required),
  })

  constructor(private authService: AuthService, public investmentService: InvestmentService, private userService: UserService, private readonly router: Router){
  }

  loginUser() : void {
    if (!this.form.valid){
      return
    }

    const loginRequest: LoginRequest = this.form.getRawValue();
    this.form.reset();
    this.authService.loginUserFromApi(loginRequest)
      .subscribe(authResult => {
        this.userService.currentUserSig.set(authResult)

        if (!this.userService.currentUserSig())
          return
        if (!this.userService.currentUserSig()!.result){
          return
        }

        localStorage.setItem("token", this.userService.currentUserSig()!.token);
        this.router.navigateByUrl("/");
        this.investmentService.getUserInvestmentsFromApi(authResult.token);
      });
  }

}
