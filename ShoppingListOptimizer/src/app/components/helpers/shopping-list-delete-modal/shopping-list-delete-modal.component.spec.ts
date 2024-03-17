import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListDeleteModalComponent } from './shopping-list-delete-modal.component';

describe('ShoppingListDeleteModalComponent', () => {
  let component: ShoppingListDeleteModalComponent;
  let fixture: ComponentFixture<ShoppingListDeleteModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListDeleteModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListDeleteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
