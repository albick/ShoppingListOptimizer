import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptimizerListRowComponent } from './optimizer-list-row.component';

describe('OptimizerListRowComponent', () => {
  let component: OptimizerListRowComponent;
  let fixture: ComponentFixture<OptimizerListRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptimizerListRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OptimizerListRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
