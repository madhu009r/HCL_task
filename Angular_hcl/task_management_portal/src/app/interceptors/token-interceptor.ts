import { HttpInterceptor } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class TokenInterceptor implements HttpInterceptor{

 intercept(req:any,next:any){

  const token=localStorage.getItem("token");

  if(token){

   req=req.clone({
    setHeaders:{
     Authorization:`Bearer ${token}`
    }
   });

  }

  return next.handle(req);

 }

}