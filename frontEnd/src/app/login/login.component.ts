import { Component } from '@angular/core';
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

  constructor(private authService: AuthService, private userService: UserService, private readonly router: Router){
  }

  doLogin(){
    if (!this.form.valid){
      return
    }

    let loginRequest: LoginRequest = this.form.getRawValue();
    this.form.reset();
    this.authService.requestAuth(loginRequest)
      .subscribe(authResult => {
        this.userService.currentUserSig.set(authResult)

        if (!this.userService.currentUserSig())
          return
        if (!this.userService.currentUserSig()!.result){
          return
        }

          localStorage.setItem("token", this.userService.currentUserSig()!.token);
          this.router.navigateByUrl("/");
      });
  }

}
