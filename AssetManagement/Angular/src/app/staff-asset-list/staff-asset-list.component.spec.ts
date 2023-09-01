import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffAssetListComponent } from './staff-asset-list.component';

describe('StaffAssetListComponent', () => {
  let component: StaffAssetListComponent;
  let fixture: ComponentFixture<StaffAssetListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StaffAssetListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StaffAssetListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
