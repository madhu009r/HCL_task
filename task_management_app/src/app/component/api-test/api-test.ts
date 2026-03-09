import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-api-test',
  imports: [],
  templateUrl: './api-test.html',
  styleUrl: './api-test.css',
})
export class ApiTest {
  user:any;
  apiUrl = 'http://localhost:5120/api';

  constructor(private http:HttpClient){}

  ngOnInit()
  {
    this.getUser();
  }

  getUser(){
    this.http.get(`${this.apiUrl}/Login`).subscribe((res: any)=>{
      console.log(res);
    })
  }

}
