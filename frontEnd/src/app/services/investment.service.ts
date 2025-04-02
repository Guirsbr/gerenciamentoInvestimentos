import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Investment } from "../models/investment.models";

@Injectable({
    providedIn:"root",
})
export class InvestmentService {

    private url = `${environment.api}/investment`

    constructor(private httpClient: HttpClient) {
    }

    getInvestments(token: string){
        const headers = new HttpHeaders({ "Authorization": `Bearer ${token}` });

        return this.httpClient.get<Investment[]>(this.url, { headers })
    }

}