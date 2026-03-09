import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { environ } from '../../environment/environ';

@Injectable({
  providedIn: 'root',
})
export class Auth {

  private apiurl = environ.apiUrl;

  constructor(private http: HttpClient){

  }

  register(user:any): Observable<any>{
    return this.http.post(`${this.apiurl}`, user);
  }

  login(user:any) : Observable<any>{
    return this.http.post(`${this.apiurl}`,user);
  }

  
  getUser(){
    return JSON.parse(localStorage.getItem("user") || '{}');
  }

  getRole(){
    const user = this.getUser();
    return user.role;
  }

  isLoggedIn(){
    return localStorage.getItem("user") != null;
  }

  logout(){
    localStorage.removeItem("user");
  }

}
