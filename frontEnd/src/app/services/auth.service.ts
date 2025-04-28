import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { LoginRequest } from "../models/loginRequest.models";
import { AuthResult } from "../models/authResult.models";
import { Observable } from "rxjs";

@Injectable({
    providedIn:"root",
})
export class AuthService {

    private url = `${environment.api}/auth`;

    private token = "";

    constructor(private httpClient: HttpClient) {
        this.setTokenFromLocalStorage();
    }

    private setTokenFromLocalStorage() : void {
        if (typeof localStorage == 'undefined')
            return
              
        this.token = localStorage.getItem("token") ?? "";
    }

    getToken() {
        return this.token
    }

    loginUserFromApi(loginRequest: LoginRequest) : Observable<AuthResult> {
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        return this.httpClient.post<AuthResult>(this.url, loginRequest, { headers })
    }

    automaticLoginFromApi(token: string): Observable<AuthResult>{
        const params = new HttpParams().set('token', token);
        
        return this.httpClient.get<AuthResult>(this.url, { params });
    }

}