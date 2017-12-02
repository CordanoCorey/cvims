import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModelControl } from '@caiu/forms';
import { HttpActions } from '@caiu/http';
import { RouterActions } from '@caiu/router';
import { SmartComponent, Store } from '@caiu/store';

import { CurrentUserActions } from '../shared/actions';
import { ResetPassword } from '../shared/models';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent extends SmartComponent implements OnInit {

  @ModelControl<ResetPassword>(new ResetPassword()) form: FormGroup;

  constructor(public store: Store<any>) {
    super(store);
  }

  get formValue(): ResetPassword {
    return this.form.value;
  }

  get userName(): AbstractControl {
    return this.form.get('userName');
  }

  get newPassword(): AbstractControl {
    return this.form.get('newPassword');
  }

  get confirmPassword(): AbstractControl {
    return this.form.get('confirmPassword');
  }

  ngOnInit() {
  }

  resetPassword(payload: ResetPassword) {
    this.dispatch(HttpActions.post(`resetpassword`, CurrentUserActions.RESET_PASSWORD));
  }

}
