import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Investment } from "../models/investment.models";
import { map, Observable } from "rxjs";

@Injectable({
    providedIn:"root",
})
export class InvestmentService {

    private investments$ = new Observable<Investment[]>();

    private url = `${environment.api}/investment`

    constructor(private httpClient: HttpClient) {
    }

    getInvestments() {
        return this.investments$
    }

    getUserInvestmentsFromApi(token: string | undefined){
        if (!token)
            return

        const headers = new HttpHeaders({ "Authorization": `Bearer ${token}` });
        const params = new HttpParams().set('token', token);

        this.investments$ = this.httpClient.get<Investment[]>(this.url, { headers, params })

        this.investments$ = this.investments$.pipe(
            map(investments => {
              return investments.map(investment => {

                if (typeof investment.initial_value === "number")
                    investment.initial_value = investment.initial_value.toFixed(2);
                if (typeof investment.current_value === "number")
                    investment.current_value = investment.current_value.toFixed(2);
                
                let dateAndTime = investment.update_date.split("T")
                investment.update_date = dateAndTime[0].replace("/-/g", "/");
                dateAndTime = investment.registration_date.split("T")
                investment.registration_date = dateAndTime[0].replace("/-/g", "/");

                return investment;
              });
            })
          );
    }

}