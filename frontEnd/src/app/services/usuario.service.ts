import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Usuario } from "../models/usuario.models";

@Injectable({
    providedIn:"root",
})
export class UsuarioService {

    private url = `${environment.api}`

    constructor(private httpClient: HttpClient) {
    }

    obterUsuario(email: string, senha: string){
        return this.httpClient.get<Usuario>(this.url + "/usuario", {
            params: {
              email: `${email}`,
              senha: `${senha}`
            }
          })
    }

    obterUsuarios(){
        return this.httpClient.get<Usuario[]>(this.url + "/usuarios")
    }

    registrarUsuario(usuario: Usuario){
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        return this.httpClient.post<null>(this.url + "/usuario", usuario, { headers })
    }

}