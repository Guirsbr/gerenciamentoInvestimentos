import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { LoginRequest } from "../models/loginRequest.models";
import { AuthResult } from "../models/authResult.models";

@Injectable({
    providedIn:"root",
})
export class AuthService {

    private url = `${environment.api}`;

    constructor(private httpClient: HttpClient) {
    }

    requestAuth(loginRequest: LoginRequest){
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        return this.httpClient.post<AuthResult>(this.url + "/auth", loginRequest, { headers })
    }

    validateUser(token: string){
        const params = new HttpParams().set('token', token);
        
        return this.httpClient.get<AuthResult>(this.url, { params });
    }

}