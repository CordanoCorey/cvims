import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'cv-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() siteLocation = 'school-store';
  @Output() logout = new EventEmitter();
  @Output() toggleSidebar = new EventEmitter();

  constructor() { }

  get cartLink(): string {
    return `/${this.siteLocation}/cart`;
  }

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
