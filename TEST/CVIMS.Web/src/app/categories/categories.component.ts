import { Component, OnInit } from '@angular/core';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { Category } from './categories.model';
import { schoolStoreCategoriesSelector, sectionCategoriesSelector } from './categories.reducer';
import { siteLocationSelector } from '../shared/selectors';

@Component({
  selector: 'cv-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent extends SmartComponent implements OnInit {

  categories$: Observable<Category[]>;
  siteLocation = 'school-store';
  siteLocation$: Observable<string>;

  tiles: any[] = [
    {text: 'One', cols: 3, rows: 1, color: 'lightblue'},
    {text: 'Two', cols: 1, rows: 2, color: 'lightgreen'},
    {text: 'Three', cols: 1, rows: 1, color: 'lightpink'},
    {text: 'Four', cols: 2, rows: 1, color: '#DDBDF1'},
  ];

  dogs: Object[] = [
    { name: 'Porter', human: 'Kara' },
    { name: 'Mal', human: 'Jeremy' },
    { name: 'Koby', human: 'Igor' },
    { name: 'Razzle', human: 'Ward' },
    { name: 'Molly', human: 'Rob' },
    { name: 'Husi', human: 'Matias' },
  ];

  basicRowHeight = 80;
  fixedCols = 4;
  fixedRowHeight = 100;
  ratioGutter = 1;
  fitListHeight = '400px';
  ratio = '4:1';

  constructor(public store: Store<any>) {
    super(store);
    this.siteLocation$ = siteLocationSelector(this.store);
    this.categories$ = sectionCategoriesSelector(this.store);
  }

  get baseUrl(): string[] {
    return [`/${this.siteLocation}/products`];
  }

  get productImageSrc(): string {
    return 'assets/images/easy.jpg';
  }

  get siteLocationChanges(): Subscription {
    return this.siteLocation$.subscribe(x => {
      this.siteLocation = x;
    });
  }

  ngOnInit() {
    this.subscribe([this.siteLocationChanges]);
    this.categories$.subscribe(x => { console.dir(x); });
  }

}
