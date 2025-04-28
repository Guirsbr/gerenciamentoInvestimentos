import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Investment } from "../models/investment.models";
import { map, Observable } from "rxjs";
import { AuthService } from "./auth.service";

@Injectable({
    providedIn:"root",
})
export class InvestmentService {

    private investments$ = new Observable<Investment[]>();

    private url = `${environment.api}/investment`

    constructor(private httpClient: HttpClient, private authService: AuthService) {
    }

    getUserInvestments() : Observable<Investment[]> {
        return this.investments$
    }

    getUserInvestmentsFromApi(token: string | undefined) : Observable<Investment[]> | void {
        if (!token)
            return

        const params = new HttpParams().set('token', token);

        this.investments$ = this.httpClient.get<Investment[]>(this.url, { params })

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

    deleteUserInvestmentFromApi(investmentId: number) : void {
        const params = new HttpParams()
            .set('investmentId', investmentId)
            .set('token', this.authService.getToken());

        this.httpClient.delete<boolean>(this.url, { params }).subscribe()
    }

}