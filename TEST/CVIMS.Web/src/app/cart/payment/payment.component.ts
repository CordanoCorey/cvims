import { Component, OnChanges, OnInit, AfterContentInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DumbComponent } from '@caiu/common';
import { Control } from '@caiu/forms';
import { Observable } from '@caiu/store';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Subscription } from 'rxjs/Subscription';

import './sqpaymentform.js';
import { PaymentInfo } from '../cart.model';
import { environment } from '../../../environments/environment';

declare var setupSqPaymentForm: any;

@Component({
  selector: 'cv-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent extends DumbComponent implements OnChanges, OnInit, AfterContentInit {

  @Input() form: FormGroup;
  @Input() nonce = '';
  @Output() changeNonce = new EventEmitter<string>();
  nonce$: Observable<string>;
  nonceSubject$: BehaviorSubject<string>;

  constructor() {
    super();
    this.nonceSubject$ = new BehaviorSubject(this.nonce);
    this.nonce$ = this.nonceSubject$.asObservable()
      .filter(x => x !== '')
      .distinctUntilChanged();
  }

  get nonceChanges(): Subscription {
    return this.nonce$.subscribe(x => {
      this.changeNonce.emit(x);
    });
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

  onSubmit(e) {
    e.preventDefault();
  }
}
