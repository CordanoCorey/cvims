import { Component, OnInit, Input, ViewEncapsulation, ViewChild, ElementRef, HostListener } from '@angular/core';

import { Category } from '../categories.model';
import {QueryItem} from '../../shared/models';

@Component({
  selector: 'cv-categories-menu',
  templateUrl: './categories-menu.component.html',
  styleUrls: ['./categories-menu.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CategoriesMenuComponent implements OnInit {

  @Input() activeId = 0;
  @Input() categories: Category[] = [];
  @Input() query: QueryItem[] = [];
  @Input() siteLocation = 'school-store';
  @ViewChild('menu') menu: ElementRef;
  _take = 0;

  constructor() {
  }

  get baseUrl(): string[] {
    return [`/${this.siteLocation}/products`];
  }

  get hasMoreCategories(): boolean {
    return this.moreCategories.length > 0;
  }

  get menuWidth(): number {
    return this.menu && this.menu.nativeElement && this.menu.nativeElement.clientWidth ? this.menu.nativeElement.clientWidth : 0;
  }

  get take(): number {
    return this._take;
  }

  set take(value: number) {
    this._take = value;
  }

  get visibleCategories(): Category[] {
    return this.take ? this.categories.filter((x, index) => index < this.take) : this.categories;
  }

  get moreCategories(): Category[] {
    return this.categories.filter((x, index) => index >= this.take);
  }

  get totalCategories(): number {
    return this.categories.length;
  }

  ngOnInit() {
    setTimeout(() => { this.loadWidthInfo(); }, 1000);
  }

  loadWidthInfo() {
    const info = this.categories.reduce((acc, x, index) => {
      const totalWidth = acc.totalWidth + x.widthPx;
      const widthExceeded = totalWidth > this.menuWidth;
      const take = widthExceeded ? acc.take : index + 1;
      return { take, totalWidth };
    }, { take: 0, totalWidth: 0 });
    this.take = info.take;
  }

  @HostListener('window:resize', ['$event'])
  onResize() {
    this.loadWidthInfo();
  }

}
