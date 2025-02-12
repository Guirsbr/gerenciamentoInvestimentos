import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { User } from "../models/user.models";

@Injectable({
    providedIn:"root",
})
export class UserService {

    private url = `${environment.api}`

    constructor(private httpClient: HttpClient) {
    }

    getUser(email: string, password: string){
        return this.httpClient.get<User>(this.url + "/user", {
            params: {
              email: `${email}`,
              password: `${password}`
            }
          })
    }

    getUsers(){
        return this.httpClient.get<User[]>(this.url + "/users")
    }

    registrateUser(user: User){
        const headers = new HttpHeaders({ "Content-Type": "application/json" });
        
        return this.httpClient.post<null>(this.url + "/user", user, { headers })
    }

}