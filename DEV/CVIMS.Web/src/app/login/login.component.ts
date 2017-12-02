import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';
import { RequestOptions } from '@angular/http';
import { ModelControl } from '@caiu/forms';
import { HttpActions, HttpPostPayload } from '@caiu/http';
import { SmartComponent, Store } from '@caiu/store';

import { Login } from '../shared/models';
import { CurrentUserActions } from '../shared/actions';

@Component({
  selector: 'cv-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends SmartComponent implements OnInit {

  @ModelControl<Login>(new Login()) form: FormGroup;

  constructor(public store: Store<any>) {
    super(store);
  }

  get credentials(): string {
    const login = <Login>this.form.value;
    return `grant_type=${login.grant_type}&username=${login.username}&password=${login.password}`;
  }

  get formValue(): Login {
    return this.form.value;
  }

  get headers(): any {
    return { 'Content-Type': 'application/x-www-form-urlencoded' };
  }

  get options(): RequestOptions {
    return new RequestOptions({ headers: this.headers });
  }

  get password(): AbstractControl {
    return this.form.get('password');
  }

  get username(): AbstractControl {
    return this.form.get('userName');
  }

  ngOnInit() {
  }

  login() {
    this.dispatch(
      HttpActions.httpPost(Object.assign(new HttpPostPayload<string>(),
        {
          path: 'token',
          model: this.credentials,
          options: this.options,
          headers: this.headers,
          onSuccess: CurrentUserActions.LOGIN,
          //  onError: this.errorOutlet
        }))
    );
  }

}
