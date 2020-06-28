import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkForUsComponent } from './work-for-us.component';

describe('WorkForUsComponent', () => {
  let component: WorkForUsComponent;
  let fixture: ComponentFixture<WorkForUsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkForUsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkForUsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
