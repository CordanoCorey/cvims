import { Component, OnInit, Inject, Input } from '@angular/core';
import {FormGroup} from '@angular/forms';
import {MatDialog, MatDialogRef} from '@angular/material';


import { DialogModel, DialogAction } from '@caiu/common';
import { build } from '@caiu/core';
import { Control, FormComponent } from '@caiu/forms';

import { Contact } from '../models';


@Component({
  selector: 'cv-contact-us-dialog',
  templateUrl: './contact-us-dialog.component.html',
  styleUrls: ['./contact-us-dialog.component.scss']
})
export class ContactUsDialogComponent extends FormComponent implements OnInit {
  //@Input() form: FormGroup;
  contact = new Contact();
   @Control(Contact) form: FormGroup;
  constructor( public dialog: MatDialog) {
    super();
  }
  // get formValue(): Contact {
  //   return this.form.value;
  // }

  get name(): string {
    return this.contact.name;
  }

  get email(): string {
    return this.contact.email;
  }

  get phone(): string {
    return this.contact.phone;
  }
  get comments(): string {
    return this.contact.comments;
  }


  // get dialogModel(): DialogModel {
  //   return build(DialogModel, {
  //     // title: 'Contact Us',
  //     actions: [build(DialogAction, { label: `Cancel` , value: 'close' })]
  //   });
  // }

  ngOnInit() {
  }

}

