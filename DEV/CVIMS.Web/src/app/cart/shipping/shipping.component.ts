import { Component, OnInit, Input, Output, EventEmitter, OnChanges, OnDestroy } from '@angular/core';
import { FormGroup, AbstractControl } from '@angular/forms';
import { Control, FormComponent } from '@caiu/forms';
import { LookupValue } from '@caiu/http';
import { Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { ShippingInfo } from '../../shared/models';

@Component({
  selector: 'cv-shipping',
  templateUrl: './shipping.component.html',
  styleUrls: ['./shipping.component.scss']
})
export class ShippingComponent extends FormComponent implements OnChanges, OnInit, OnDestroy {

  @Input() form: FormGroup;
  @Input() shippingOptions: LookupValue[] = [];
  @Input() states: LookupValue[] = [];
  @Output() changeShippingOption = new EventEmitter<number>();
  shippingOptionId$: Observable<number>;
  shippingOptionIdChanges: Subscription;

  constructor() {
    super();
  }

  get shippingOptionIdControl(): AbstractControl {
    return this.form && this.form.controls ? this.form.controls['shippingOptionId'] : null;
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

  ngOnChanges() {
    if (this.shippingOptionIdControl && !this.shippingOptionIdChanges) {
      this.shippingOptionId$ = this.shippingOptionIdControl.valueChanges.distinctUntilChanged();
      this.shippingOptionIdChanges = this.shippingOptionId$.subscribe(id => {
        this.changeShippingOption.emit(id);
      });
    }
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    super.ngOnDestroy();
    this.shippingOptionIdChanges.unsubscribe();
  }

}
