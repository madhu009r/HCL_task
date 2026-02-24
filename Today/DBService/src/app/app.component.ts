import { Component } from '@angular/core';
import { bookService } from './Service/book.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
   books: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    

    this.http.get<any[]>('http://localhost:5212/api/Book')
      .subscribe({
        next: (data) => {
          console.log("API Data:", data);
          this.books = data;
        },
        error: (err) => {
          console.log("API Error:", err);
        }
      });
  }
}
