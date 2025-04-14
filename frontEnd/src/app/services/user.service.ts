import { Injectable, signal } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
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

    registrateUser(user: User){
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        return this.httpClient.post<null>(this.url, user, { headers })
    }

}