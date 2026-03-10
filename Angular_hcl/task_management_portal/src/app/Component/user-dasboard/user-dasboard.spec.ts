import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDasboard } from './user-dasboard';

describe('UserDasboard', () => {
  let component: UserDasboard;
  let fixture: ComponentFixture<UserDasboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserDasboard],
    }).compileComponents();

    fixture = TestBed.createComponent(UserDasboard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
