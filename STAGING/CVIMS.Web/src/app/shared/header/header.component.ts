import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Output() logout = new EventEmitter();
  @Output() toggleSidebar = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  onLogout() {
    this.logout.emit();
  }

  onToggleSidebar() {
    this.toggleSidebar.emit();
  }

  toggleUser() {

  }

}
