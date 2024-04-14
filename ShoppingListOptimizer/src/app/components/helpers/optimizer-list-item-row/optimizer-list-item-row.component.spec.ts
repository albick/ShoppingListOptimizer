import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptimizerListItemRowComponent } from './optimizer-list-item-row.component';

describe('OptimizerListItemRowComponent', () => {
  let component: OptimizerListItemRowComponent;
  let fixture: ComponentFixture<OptimizerListItemRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptimizerListItemRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OptimizerListItemRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
