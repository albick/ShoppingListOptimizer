import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptimizerSelectOptionsComponent } from './optimizer-select-options.component';

describe('OptimizerSelectOptionsComponent', () => {
  let component: OptimizerSelectOptionsComponent;
  let fixture: ComponentFixture<OptimizerSelectOptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptimizerSelectOptionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OptimizerSelectOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
