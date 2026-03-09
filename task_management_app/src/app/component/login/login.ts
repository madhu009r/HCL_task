import { Component } from '@angular/core';
import { Auth } from '../../service/auth';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  loginData:any = {
    username: '',
    password: ''
  };

  constructor(private auth: Auth){}

  LoginUser(){
    this.auth.login(this.loginData).subscribe({
      next:(res)=>{
        console.log("User Logged In", res);
        localStorage.setItem("user", JSON.stringify(res));

        // redirect based on role
        // if(res.role === "Admin"){
        //   this.Router.navigate(['/user']);
        // }
        // else{
        //   this.router.navigate(['/user-dashboard']);
        // }
      
      }
    })
  }

}
