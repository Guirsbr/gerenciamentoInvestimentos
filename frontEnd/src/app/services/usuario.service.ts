import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Usuario } from "../models/usuario.models";

@Injectable({
    providedIn:"root",
})
export class UsuarioService {

    private url = environment.api

    constructor(private httpClient: HttpClient) {
    }

    obterUsuarios(){
        return this.httpClient.get<Usuario[]>(this.url + "usuarios")
    }

}