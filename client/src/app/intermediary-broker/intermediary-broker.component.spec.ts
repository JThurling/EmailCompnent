import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IntermediaryBrokerComponent } from './intermediary-broker.component';

describe('IntermediaryBrokerComponent', () => {
  let component: IntermediaryBrokerComponent;
  let fixture: ComponentFixture<IntermediaryBrokerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IntermediaryBrokerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IntermediaryBrokerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
