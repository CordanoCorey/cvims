import { Component, OnInit, Input } from '@angular/core';

import { QueryItem } from '../models';

@Component({
  selector: 'cv-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  @Input() query: QueryItem[] = [];

  constructor() { }

  ngOnInit() {
  }

}
