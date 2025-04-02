import { Component } from '@angular/core';
import { AuthResult } from '../models/authResult.models';
import { AuthService } from '../services/auth.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginRequest } from '../models/loginRequest.models';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';


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
  
  authResult: AuthResult = {token: "", result: false, name: ""};

  constructor(private authService: AuthService, private userService: UserService, private readonly router: Router){
  }

  doLogin(){
    if (this.form.valid) {
      let loginRequest: LoginRequest = this.form.getRawValue();
      this.form.reset();
      this.authService.requestAuth(loginRequest)
        .subscribe(authResult => {
          this.authResult = authResult;
          if (this.authResult.result) {
            localStorage.setItem("token", this.authResult.token);
            this.userService.currentUserSig.set(authResult)
            this.router.navigateByUrl("/");
          }
        });
    }
  }

}
