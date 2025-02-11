import { Component } from '@angular/core';
import { InvestimentoService } from './services/investimento.service';
import { Investimento } from './models/investimento.models';
import { UsuarioService } from './services/usuario.service';
import { Usuario } from './models/usuario.models';
import { CommonModule } from '@angular/common';
import { LoginComponent } from "./login/login.component";
import { RegistrationComponent } from './registration/registration.component';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [CommonModule, RegistrationComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontEnd';

  investimentos$ = new Observable<Investimento[]>();
  usuarios$ = new Observable<Usuario[]>();
  usuario$ = new Observable<Usuario>();

  constructor(private investimentoService: InvestimentoService, private usuarioService: UsuarioService){
    // this.obterInvestimentosDoUsuario();
    // this.obterUsuariosDoSistema();
    // this.obterUsuarioEspecifico();
  }

  obterInvestimentosDoUsuario(){
    this.investimentos$ = this.investimentoService.obterInvestimentos();
  }

  obterUsuariosDoSistema(){
    this.usuarios$ = this.usuarioService.obterUsuarios();
  }

  obterUsuarioEspecifico(){
    this.usuario$ = this.usuarioService.obterUsuario("teste@hotmail.com", "12345");
  }

}
