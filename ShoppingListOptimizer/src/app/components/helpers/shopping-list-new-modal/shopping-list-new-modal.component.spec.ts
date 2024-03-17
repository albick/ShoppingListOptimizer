import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListNewModalComponent } from './shopping-list-new-modal.component';

describe('ShoppingListNewModalComponent', () => {
  let component: ShoppingListNewModalComponent;
  let fixture: ComponentFixture<ShoppingListNewModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListNewModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListNewModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
