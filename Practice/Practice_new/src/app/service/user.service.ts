import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiurl ="http://localhost:5066/api/User";
  
  constructor(private Http: HttpClient){}

  getAllUsers()
  {
    return this.Http.get<any[]>(this.apiurl);
  }
}
