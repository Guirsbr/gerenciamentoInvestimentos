import { Component, inject } from '@angular/core';
import { AuthResult } from '../models/authResult.models';
import { LoginRequestService } from '../services/loginRequest.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginRequest } from '../models/loginRequest.models';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  title = 'login';

  authService = inject(AuthService)

  form = new FormGroup({
    email: new FormControl("", Validators.required),
    password: new FormControl("", Validators.required),
  })
  authResult: AuthResult = {token: "", result: false, name: ""};

  constructor(private loginRequestService: LoginRequestService, authService: AuthService){
    this.loadData();
  }

  doLogin(){
    if (this.form.valid) {
      let loginRequest: LoginRequest = this.form.getRawValue();
      this.form.reset();
      this.loginRequestService.requestAuth(loginRequest)
        .subscribe(authResult => {
          this.authResult = authResult;
          if (this.authResult.result) {
            localStorage.setItem("token", this.authResult.token);
            this.authService.currentUserSig.set(authResult)
          }
        });
    }
  }

  loadData(){
    if (typeof localStorage !== 'undefined') {
      let token: string | null = localStorage.getItem("token");
      if (token)
        this.authResult.token = token;
    }
  }

}
