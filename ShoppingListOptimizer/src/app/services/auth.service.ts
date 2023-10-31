import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {JwtResponse} from "../models/jwt-response";
import {MessageResponse} from "../models/message-response";

const AUTH_API = 'https://localhost:7090/api/Account/';

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

  login(username: string, password: string): Observable<JwtResponse> {
    return this.http.post<JwtResponse>(AUTH_API + 'login', {
      username,
      password
    }, httpOptions);
  }

  register(username: string, email: string, password: string): Observable<any> {
    return this.http.post<any>(AUTH_API + 'register', {
      username,
      email,
      password
    }, httpOptions);
  }
}
