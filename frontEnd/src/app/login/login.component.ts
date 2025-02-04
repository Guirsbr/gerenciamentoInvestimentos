import { Component } from '@angular/core';
import { AuthResult } from '../models/authResult.models';
import { LoginRequestService } from '../services/loginRequest.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  title = 'login';
  
  // Form
  email = "";
  senha = "";
  
  authResult: AuthResult = {token: "", result: false, nome: ""};

  constructor(private loginRequestService: LoginRequestService){

  }

  fazerLogin(){
    if (!this.email || !this.senha)
      return;

    this.loginRequestService.requestAuth({ email: this.email, senha: this.senha })
      .subscribe(authResult => {
        this.authResult = authResult;
        if (this.authResult.result)
          localStorage.setItem("session", JSON.stringify(this.authResult));
      });
  }

}
