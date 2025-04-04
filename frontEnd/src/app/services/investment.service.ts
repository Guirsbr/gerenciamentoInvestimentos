import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Investment } from "../models/investment.models";

@Injectable({
    providedIn:"root",
})
export class InvestmentService {

    private url = `${environment.api}/investment`

    constructor(private httpClient: HttpClient) {
    }

    getUserInvestments(token: string){
        const headers = new HttpHeaders({ "Authorization": `Bearer ${token}` });
        const params = new HttpParams().set('token', token);

        return this.httpClient.get<Investment[]>(this.url, { headers, params })
    }

}