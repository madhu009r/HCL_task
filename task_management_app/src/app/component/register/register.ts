import { Component } from '@angular/core';
import { create } from 'domain';
import { Auth } from '../../service/auth';
import { User } from '../../models/user.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [CommonModule, FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {

  user:any = {
    name: '',
    password: '',
    role: '',
    createdAt: new Date()
  };

  constructor(private auth: Auth ){}

  resgisterUser(){
    this.auth.register(this.user).subscribe({
      next:(res)=>{
        console.log("User Registered", res);
        alert("Registration Successful");
      },
      error:(err)=>{
        console.log(err);
        alert("Registration Failed");
      }
    });

  }

}
