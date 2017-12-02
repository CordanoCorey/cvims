import { Component, OnChanges, OnInit, AfterContentInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, AbstractControl } from '@angular/forms';
import { getValue } from '@caiu/core';
import { DumbComponent } from '@caiu/common';
import { Control, FormComponent } from '@caiu/forms';
import { LookupValue } from '@caiu/http';
import { Observable } from '@caiu/store';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Subscription } from 'rxjs/Subscription';
import './sqpaymentform.js';

import { PaymentInfo } from '../cart.model';
import { Address, ShippingInfo } from '../../shared/models';
import { environment } from '../../../environments/environment';

declare var setupSqPaymentForm: any;

@Component({
  selector: 'cv-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent extends FormComponent implements OnChanges, OnInit, AfterContentInit {

  @Input() form: FormGroup;
  @Input() nonce = '';
  @Input() shippingAddress: Address = new Address();
  @Input() shippingOptions: LookupValue[] = [];
  @Input() states: LookupValue[] = [];
  @Output() changeNonce = new EventEmitter<string>();
  nonce$: Observable<string>;
  nonceSubject$: BehaviorSubject<string>;
  useShippingAddress = false;

  constructor() {
    super();
    this.nonceSubject$ = new BehaviorSubject(this.nonce);
    this.nonce$ = this.nonceSubject$.asObservable()
      .filter(x => x !== '')
      .distinctUntilChanged();
  }

  get billingAddressControl(): AbstractControl {
    return this.form.controls['billingAddress'];
  }

  get newBillingAddress(): Address {
    return this.useShippingAddress ? getValue(this.shippingAddress) : getValue(new Address());
  }

  get nonceChanges(): Subscription {
    return this.nonce$.subscribe(x => {
      this.changeNonce.emit(x);
    });
  }

  get shipToStore(): boolean {
    return false;
    // return this.form.value.shippingOptionId === 1;
  }

  get shipToAddress(): boolean {
    return true;
    //  return this.form.value.shippingOptionId === 2;
  }

  get shipToBuilding(): boolean {
    return false;
    //  return this.form.value.shippingOptionId === 3;
  }

  get shippingCity(): string {
    return this.shippingAddress ? this.shippingAddress.city : '';
  }

  get shippingState(): string {
    const state = this.states.find(x => x.id === this.shippingAddress.stateId);
    return state ? state.name : '';
  }

  get shippingZipCode(): number {
    return this.shippingAddress ? this.shippingAddress.zipCode : 0;
  }

  get shippingCityStateZip(): string {
    return this.shippingCity && this.shippingState && this.shippingZipCode ?
      `${this.shippingCity}, ${this.shippingState} ${this.shippingZipCode} ` : '';
  }

  ngOnChanges() {
    this.nonceSubject$.next(this.nonce);
  }

  ngOnInit() {
    this.subscribe([this.nonceChanges]);
  }

  ngAfterContentInit() {
    setTimeout(() => {
      setupSqPaymentForm(environment.sqPaymentLocationId, environment.sqPaymentAppId);
    }, 0);
  }

  changeUseShippingAddress(value: boolean) {
    this.useShippingAddress = value;
    this.resetBillingAddress();
  }

  onSubmit(e) {
    e.preventDefault();
  }

  resetBillingAddress() {
    this.billingAddressControl.setValue(this.newBillingAddress);
  }

}
