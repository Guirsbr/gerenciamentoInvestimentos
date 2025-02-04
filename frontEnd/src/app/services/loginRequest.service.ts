import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { LoginRequest } from "../models/loginRequest.models";
import { AuthResult } from "../models/authResult.models";

@Injectable({
    providedIn:"root",
})
export class LoginRequestService {

    private url = `${environment.api}/auth`;

    constructor(private httpClient: HttpClient) {
    }

    requestAuth(loginRequest: LoginRequest){
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        return this.httpClient.post<AuthResult>(this.url, loginRequest, { headers })
    }

}