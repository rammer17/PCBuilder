import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PcBuildComponent } from './pc-build.component';

describe('PcBuildComponent', () => {
  let component: PcBuildComponent;
  let fixture: ComponentFixture<PcBuildComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PcBuildComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PcBuildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
