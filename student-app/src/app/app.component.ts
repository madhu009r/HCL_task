import { Component } from '@angular/core';
import { StudentService } from './service/student.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

   students: any[] = [];
  student = { id: 0, name: '' };
  isEditMode = false;

  constructor(private studentService: StudentService) {}

  ngOnInit() {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    });
  }

  saveStudent() {
    if (!this.student.name.trim()) return;

    if (!this.isEditMode) {
      this.studentService.addStudent(this.student).subscribe(() => {
        this.loadStudents();
      });
    } else {
      this.studentService.updateStudent(this.student.id, this.student).subscribe(() => {
        this.loadStudents();
      });
      this.isEditMode = false;
    }

    this.student = { id: 0, name: '' };
  }

  editStudent(stu: any) {
    this.student = { ...stu };
    this.isEditMode = true;
  }

  deleteStudent(id: number) {
    if (confirm('Are you sure you want to delete?')) {
      this.studentService.deleteStudent(id).subscribe(() => {
        this.loadStudents();
      });
    }
  }

  cancelEdit() {
    this.student = { id: 0, name: '' };
    this.isEditMode = false;
  }
   
}
