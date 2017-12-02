import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'cv-totals',
  templateUrl: './totals.component.html',
  styleUrls: ['./totals.component.scss']
})
export class TotalsComponent implements OnInit {

  @Input() subtotal = 0;
  @Input() tax = 0;
  @Input() total = 0;

  constructor() { }

  get computedTotal(): number {
    return this.total || this.subtotal + this.tax;
  }

  ngOnInit() {
  }

}
