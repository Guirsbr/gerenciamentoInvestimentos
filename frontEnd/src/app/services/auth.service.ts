import { Injectable, signal } from "@angular/core";
import { AuthResult } from "../models/authResult.models";

@Injectable({
    providedIn:"root",
})
export class AuthService {
    currentUserSig = signal<AuthResult | undefined | null>(undefined);
}