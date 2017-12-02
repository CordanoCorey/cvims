import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolStoreComponent } from './school-store.component';

describe('SchoolStoreComponent', () => {
  let component: SchoolStoreComponent;
  let fixture: ComponentFixture<SchoolStoreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SchoolStoreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
