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

    registrateUserFromApi(user: User) : void{
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        this.httpClient.post<null>(this.url, user, { headers }).subscribe()
    }

}