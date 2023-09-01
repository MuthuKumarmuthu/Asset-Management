import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffAssetDetailsComponent } from './staff-asset-details.component';

describe('StaffAssetDetailsComponent', () => {
  let component: StaffAssetDetailsComponent;
  let fixture: ComponentFixture<StaffAssetDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StaffAssetDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StaffAssetDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
