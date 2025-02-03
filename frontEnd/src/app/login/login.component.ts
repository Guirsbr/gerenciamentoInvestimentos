import { Component } from '@angular/core';
import { AuthResult } from '../models/authResult.models';
import { LoginRequest } from '../models/loginRequest.models';
import { LoginRequestService } from '../services/loginRequest.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  // declare authResult: AuthResult;
  // // authResult$ = new Observable<AuthResult>();
  // loginRequest: LoginRequest = {
  //   email: "teste@hotmail.com",
  //   senha: "12345",
  // };

  // constructor(private loginRequestService: LoginRequestService){
  //     this.fazerLogin();
  // }

  // fazerLogin(){
  //   // this.authResult$ = this.loginRequestService.requestAuth(this.loginRequest);
  //   this.loginRequestService.requestAuth(this.loginRequest)
  //     .subscribe(authResult => this.authResult = authResult)
  // }
}
