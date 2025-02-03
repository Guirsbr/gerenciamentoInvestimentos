import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment.development";
import { Investimento } from "../models/investimento.models";

@Injectable({
    providedIn:"root",
})
export class InvestimentoService {

    private url = environment.api

    constructor(private httpClient: HttpClient) {
    }

    obterInvestimentos(){
        return this.httpClient.get<Investimento[]>(this.url + "investimento")
    }

}