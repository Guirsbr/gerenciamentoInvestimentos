import { Injectable, signal } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { User } from "../models/user.models";
import { AuthResult } from "../models/authResult.models";

@Injectable({
    providedIn:"root",
})
export class UserService {

    currentUserSig = signal<AuthResult | undefined | null>(undefined);

    private url = `${environment.api}/user`

    constructor(private httpClient: HttpClient) {
    }
    
    validateUser(token: string){
        const headers = new HttpHeaders({ "Authorization": `Bearer ${token}` });
        const params = new HttpParams().set('token', token);
        
        return this.httpClient.get<AuthResult>(this.url, { headers, params });
    }

    registrateUser(user: User){
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        return this.httpClient.post<null>(this.url, user, { headers })
    }

}