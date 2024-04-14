import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptimizerListsComponent } from './optimizer-lists.component';

describe('OptimizerListsComponent', () => {
  let component: OptimizerListsComponent;
  let fixture: ComponentFixture<OptimizerListsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptimizerListsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OptimizerListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
