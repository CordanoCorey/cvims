import { Component, OnInit } from '@angular/core';
import { SmartComponent, Store } from '@caiu/store';

@Component({
  selector: 'cv-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends SmartComponent implements OnInit {

  constructor(public store: Store<any>) {
    super(store);
  }

  ngOnInit() {
  }

}
