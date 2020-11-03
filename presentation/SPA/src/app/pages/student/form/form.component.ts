import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {

  id = 0;
  form: FormGroup;

  formProperties = {
    Username: {
      maxCaracteres: 20,
      validationMessages: {
        required: 'Required',
      },
    },
    FirstName: {
      maxCaracteres: 20,
      validationMessages: {
        required: 'Required',
      },
    },
    LastName: {
      maxCaracteres: 20,
      validationMessages: {
        required: 'Required',
      },
    },
    Age: {
      validationMessages: {
        required: 'Required',
      },
    },
    Career: {
      maxCaracteres: 20,
      validationMessages: {
        required: 'Required',
      },
    },
  };

  constructor(
    public modal: NgbActiveModal,
    private formBuilder: FormBuilder,
    private studentService: StudentService
  ) {
    this.buildForm();
  }

  ngOnInit(): void {
    this.getContent();
  }

  getContent(): void {
    if (this.id !== 0) {
      this.studentService.get(this.id)
      .subscribe(response => {
        this.form.patchValue(response);
      });
    }
  }

  private buildForm(): void {
    this.form = this.formBuilder.group({
      Id: 0,
      Username: [ '',
        [
          Validators.required,
          Validators.maxLength(this.formProperties.Username.maxCaracteres),
        ],
      ],
      FirstName: [ '',
        [
          Validators.required,
          Validators.maxLength(this.formProperties.Username.maxCaracteres),
        ],
      ],
      LastName: [ '',
        [
          Validators.required,
          Validators.maxLength(this.formProperties.Username.maxCaracteres),
        ],
      ],
      Age: [ '',
        [
          Validators.required,
        ],
      ],
      Career: [ '',
        [
          Validators.required,
          Validators.maxLength(this.formProperties.Career.maxCaracteres),
        ],
      ]
    });
  }

  save(event: Event): void {
    if (this.form.valid) {
      const student = this.form.value;
      if (this.id === 0) {
        this.studentService.create(student)
        .subscribe(response => {
          this.modal.close(response);
        });
      }
      else {
        this.studentService.update(this.id, student)
        .subscribe(response => {
          this.modal.close(response);
        });
      }
    }
  }
}
