import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, FormComponent } from '@caiu/forms';
import { LookupValue } from '@caiu/http';

import { ShippingInfo } from '../../shared/models';

@Component({
  selector: 'cv-shipping',
  templateUrl: './shipping.component.html',
  styleUrls: ['./shipping.component.scss']
})
export class ShippingComponent extends FormComponent implements OnInit {

  @Input() form: FormGroup;
  @Input() shippingOptions: LookupValue[] = [];
  @Input() states: LookupValue[] = [];

  constructor() {
    super();
  }

  get storePickup(): boolean {
    return this.form.get('shippingOptionId').value === 1;
  }

  get shipToAddress(): boolean {
    return this.form.get('shippingOptionId').value === 2;
  }

  get shipToBuilding(): boolean {
    return this.form.get('shippingOptionId').value === 3;
  }

  ngOnInit() {
  }

}
