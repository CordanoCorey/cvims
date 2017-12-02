import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'cv-charge',
  templateUrl: './charge.component.html',
  styleUrls: ['./charge.component.scss']
})
export class ChargeComponent implements OnInit {

  @Output() submitCharge = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }
  ngOnSubmit(e) {
    this.submitCharge.emit(e);
  }

}
