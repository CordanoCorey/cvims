import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersGridComponent } from './orders-grid.component';

describe('OrdersGridComponent', () => {
  let component: OrdersGridComponent;
  let fixture: ComponentFixture<OrdersGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdersGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
