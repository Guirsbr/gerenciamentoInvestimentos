import { Component } from '@angular/core';
import { AuthResult } from '../models/authResult.models';
import { LoginRequestService } from '../services/loginRequest.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginRequest } from '../models/loginRequest.models';


@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  title = 'login';

  form: FormGroup;
  authResult: AuthResult = {token: "", result: false, nome: ""};

  constructor(private loginRequestService: LoginRequestService){
    this.form = new FormGroup({
          email: new FormControl("", Validators.required),
          senha: new FormControl("", Validators.required),
    })
    this.loadData();
  }

  fazerLogin(){
    if (this.form.valid) {
      let loginRequest: LoginRequest = this.form.getRawValue();
      this.form.reset();
      this.loginRequestService.requestAuth(loginRequest)
        .subscribe(authResult => {
          this.authResult = authResult;
          if (this.authResult.result)
            localStorage.setItem("session", JSON.stringify(this.authResult));
        });
    }
  }

  loadData(){
    if (typeof localStorage !== 'undefined') {
      let data: any = localStorage.getItem("session");
      this.authResult = JSON.parse(data);
    }
  }

}
