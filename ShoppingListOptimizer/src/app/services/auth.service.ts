import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {JwtResponse} from "../models/jwt-response";
import {MessageResponse} from "../models/message-response";
import {Environment} from "../../environment/env";
import {
    JwtAuthResponse,
    LoginRequest,
    RegisterRequest,
    RegisterResponse,
    RegisterShopRequest,
    LocationModel
} from "../models/generated";

const AUTH_API = Environment.apiUrl+':'+Environment.apiPort+'/api/Account/';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'withCredentials': 'true'
    })
};

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient) {
    }

    login(email: string, password: string): Observable<JwtAuthResponse> {
        let loginRequest: LoginRequest = {Email: email, Password: password};
        return this.http.post<JwtAuthResponse>(AUTH_API + 'login', loginRequest, httpOptions);
    }

    registerUser(username: string, email: string, password: string): Observable<RegisterResponse> {
        let registerRequest: RegisterRequest = {UserName: username, Email: email, Password: password};
        return this.http.post<RegisterResponse>(AUTH_API + 'register', registerRequest, httpOptions);
    }

    registerShop(company: string, email: string, password: string, location: LocationModel): Observable<RegisterResponse> {
        let _location: LocationModel = {
            city: location.city,
            postcode: location.postcode,
            street: location.street,
            number: location.number,
            longitude: location.longitude,
            latitude: location.latitude
        };
        let registerRequest: RegisterShopRequest = {Company: company, Email: email, Password: password, Location: _location};
        return this.http.post<RegisterResponse>(AUTH_API + 'register-shop', registerRequest, httpOptions);
    }
}
