import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from './../auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  private formSubmitAttempt: boolean|undefined;

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.form = this.fb.group({
      username: [''],
      password: ['', Validators.required],
    });
  }

  ngOnInit() {
  }

  isFieldInvalid(field: string) {
    let fieldValue= this.form!.get(field);
    return (
      (fieldValue!=null &&((!fieldValue.valid && fieldValue.touched) ||
      (fieldValue.untouched && this.formSubmitAttempt)))
    );
  }

  onSubmit() {
    if (this.form!.valid) {
      this.authService.login(this.form!.value);
    }
    this.formSubmitAttempt = true;
  }
}
