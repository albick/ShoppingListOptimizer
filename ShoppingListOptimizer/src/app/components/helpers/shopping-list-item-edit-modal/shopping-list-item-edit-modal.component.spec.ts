import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListItemEditModalComponent } from './shopping-list-item-edit-modal.component';

describe('ShoppingListItemEditModalComponent', () => {
  let component: ShoppingListItemEditModalComponent;
  let fixture: ComponentFixture<ShoppingListItemEditModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListItemEditModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListItemEditModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
