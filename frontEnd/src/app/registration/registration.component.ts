import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsuarioService } from '../services/usuario.service';
import { Usuario } from '../models/usuario.models';

@Component({
  selector: 'app-registration',
  imports: [ReactiveFormsModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  title = 'registration';

  form: FormGroup;

  constructor(private usuarioService: UsuarioService){
    this.form = new FormGroup({
      nome: new FormControl("", Validators.required),
      email: new FormControl("", Validators.required),
      senha: new FormControl("", Validators.required),
    })
  }

  fazerCadastro(){
    if (this.form.valid) {
      let usuario: Usuario = this.form.getRawValue();
      this.form.reset();
      this.usuarioService.registrarUsuario(usuario).subscribe();
    }
  }
  
}
