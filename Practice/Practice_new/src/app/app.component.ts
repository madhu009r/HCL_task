import { Component } from '@angular/core';
import { UserService } from './service/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  //title = 'Practice_new';


  users: any[] = [];
  constructor(private user: UserService) {
    
  }

  ngOnInit(){
    this.loadUsers();
  }
  loadUsers(){
    this.user.getAllUsers().subscribe((data: any[]) => {
      this.users = data;
    });
    
  }
}
