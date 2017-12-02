import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplyStoreComponent } from './supply-store.component';

describe('SupplyStoreComponent', () => {
  let component: SupplyStoreComponent;
  let fixture: ComponentFixture<SupplyStoreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupplyStoreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplyStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
