import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationSidenavComponent } from './notification-sidenav.component';

describe('NotificationSidenavComponent', () => {
  let component: NotificationSidenavComponent;
  let fixture: ComponentFixture<NotificationSidenavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotificationSidenavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotificationSidenavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
