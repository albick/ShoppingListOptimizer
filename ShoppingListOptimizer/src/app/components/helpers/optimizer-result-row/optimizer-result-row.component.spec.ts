import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptimizerResultRowComponent } from './optimizer-result-row.component';

describe('OptimizerResultRowComponent', () => {
  let component: OptimizerResultRowComponent;
  let fixture: ComponentFixture<OptimizerResultRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptimizerResultRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OptimizerResultRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
