import { Component } from '@angular/core';
import { AuthService } from '../../service/auth';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  loginData={
    email:'',
    PasswordHash:''
  }

  constructor(private auth:AuthService, private router:Router){}

  login(){

    this.auth.login(this.loginData).subscribe((res:any)=>{

      this.auth.saveToken(res.token);

      if(res.role == "Admin"){
        this.router.navigate(['/admin']);
      }
      else{
        this.router.navigate(['/user']);
      }

    });

  }
}
