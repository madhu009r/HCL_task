import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class bookService {

  private apiUrl = 'http://localhost:5212/api/Book';

  constructor(private http: HttpClient) {}

  getCountries() {
    return this.http.get<any[]>(this.apiUrl);
  }
}
