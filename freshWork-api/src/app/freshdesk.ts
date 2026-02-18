import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Freshdesk {

  private baseUrl = 'http://localhost:5233/api/tickets';

  constructor(@Inject(HttpClient) private http: HttpClient) {}

  getTickets() {
    return this.http.get(this.baseUrl);
  }

  getTicketById(id: number) {
  return this.http.get(`${this.baseUrl}/${id}`);
}

  createTicket(data: any) {
    return this.http.post(this.baseUrl, data);
  }

  updateTicket(id: number, data: any) {
    return this.http.put(`${this.baseUrl}/${id}`, data);
  }

  deleteTicket(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
