import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartPreviewComponent } from './cart-preview.component';

describe('CartPreviewComponent', () => {
  let component: CartPreviewComponent;
  let fixture: ComponentFixture<CartPreviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartPreviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
