import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Investment } from "../models/investment.models";
import { Observable } from "rxjs";

@Injectable({
    providedIn:"root",
})
export class InvestmentService {

    investment$ = new Observable<Investment[]>();

    private url = `${environment.api}/investment`

    constructor(private httpClient: HttpClient) {
    }

    getUserInvestments(token: string | undefined){
        if (!token)
            return

        const headers = new HttpHeaders({ "Authorization": `Bearer ${token}` });
        const params = new HttpParams().set('token', token);

        this.investment$ = this.httpClient.get<Investment[]>(this.url, { headers, params })
    }

}