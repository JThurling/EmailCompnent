import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HelpDonationComponent } from './help-donation.component';

describe('HelpDonationComponent', () => {
  let component: HelpDonationComponent;
  let fixture: ComponentFixture<HelpDonationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HelpDonationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HelpDonationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
