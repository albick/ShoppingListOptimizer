import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListAddRowComponent } from './shopping-list-add-row.component';

describe('ShoppingListAddRowComponent', () => {
  let component: ShoppingListAddRowComponent;
  let fixture: ComponentFixture<ShoppingListAddRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListAddRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListAddRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
