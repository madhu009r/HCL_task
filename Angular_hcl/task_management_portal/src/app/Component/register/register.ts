import { Component } from '@angular/core';
import { AuthService } from '../../service/auth';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-register',
  imports: [FormsModule, CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {

   user={
    name:'',
    email:'',
    PasswordHash:'',
    role:''
  }

  constructor(private auth:AuthService){}

  register(){

    this.auth.register(this.user).subscribe(res=>{
      alert("Registration successful");
    });

  }

}
