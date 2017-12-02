import { Component, OnInit } from '@angular/core';
import { SmartComponent, Store } from '@caiu/store';

@Component({
  selector: 'cv-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent extends SmartComponent implements OnInit {

  constructor(public store: Store<any>) {
    super(store);
  }

  ngOnInit() {
  }

}
