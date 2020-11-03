import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

// Services
import { StudentService } from './../../services/student.service';

// Models
import { Student } from './../../models/student.model';
import { FormComponent } from './form/form.component';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  students: Student[] = [];
  student: Student;

  constructor(
    private modalService: NgbModal,
    private studentService: StudentService
  ) { }

  ngOnInit(): void {
    this.fetchStudents();
  }

  fetchStudents(): void {
    this.studentService.getAll()
    .subscribe(response => {
      this.students = response;
      console.log(response);
    });
  }

  studentForm(id: number): void {
    const ref = this.modalService.open(FormComponent, {
      size: 'xl',
      centered: true,
      backdrop: 'static',
      keyboard: false,
    });
    ref.componentInstance.id = id;
    ref.result.then(response => {
      this.fetchStudents();
    });
  }

  delete(id: number): void {
    this.studentService.delete(id)
    .subscribe(response => {
      this.fetchStudents();
    });
  }
}
