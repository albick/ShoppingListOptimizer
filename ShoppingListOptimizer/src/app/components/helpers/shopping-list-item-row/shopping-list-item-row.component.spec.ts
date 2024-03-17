import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListItemRowComponent } from './shopping-list-item-row.component';

describe('ShoppingListItemRowComponent', () => {
  let component: ShoppingListItemRowComponent;
  let fixture: ComponentFixture<ShoppingListItemRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListItemRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListItemRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
