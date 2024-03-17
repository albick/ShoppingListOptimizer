import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListItemDeleteModalComponent } from './shopping-list-item-delete-modal.component';

describe('ShoppingListItemDeleteModalComponent', () => {
  let component: ShoppingListItemDeleteModalComponent;
  let fixture: ComponentFixture<ShoppingListItemDeleteModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListItemDeleteModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListItemDeleteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
