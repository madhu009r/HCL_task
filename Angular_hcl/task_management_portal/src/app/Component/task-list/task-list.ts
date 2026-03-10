import { Component } from '@angular/core';
import { Task } from '../../service/task';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-list',
  imports: [FormsModule, CommonModule],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})
export class TaskList {

  tasks:any[]=[];

 constructor(private taskService:Task){}

 ngOnInit(){

  this.taskService.getTasks().subscribe((res:any)=>{
    this.tasks=res;
  });

 }

 deleteTask(id:number){

  this.taskService.deleteTask(id).subscribe(()=>{
    this.ngOnInit();
  });

 }

}
