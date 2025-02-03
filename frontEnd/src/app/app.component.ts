import { Component } from '@angular/core';
import { InvestimentoService } from './services/investimento.service';
import { Investimento } from './models/investimento.models';
import { UsuarioService } from './services/usuario.service';
import { Usuario } from './models/usuario.models';
import { CommonModule } from '@angular/common';
import { LoginComponent } from "./login/login.component";
import { Observable } from 'rxjs';
import { AuthResult } from './models/authResult.models';
import { LoginRequest } from './models/loginRequest.models';
import { LoginRequestService } from './services/loginRequest.service';


@Component({
  selector: 'app-root',
  imports: [CommonModule, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontEnd';

  investimentos$ = new Observable<Investimento[]>();
  usuarios$ = new Observable<Usuario[]>();

  authResult$ = new Observable<AuthResult>();

  loginRequest: LoginRequest = {
    email: "teste@hotmail.com",
    senha: "12345",
  };

  constructor(private investimentoService: InvestimentoService, private usuarioService: UsuarioService, private loginRequestService: LoginRequestService){
    this.obterInvestimentosDoUsuario();
    this.obterUsuariosDoSistema();
    this.fazerLogin();
  }

  obterInvestimentosDoUsuario(){
    this.investimentos$ = this.investimentoService.obterInvestimentos();
  }

  obterUsuariosDoSistema(){
    this.usuarios$ = this.usuarioService.obterUsuarios();
  }

  fazerLogin(){
    this.authResult$ = this.loginRequestService.requestAuth(this.loginRequest);
  }
}
