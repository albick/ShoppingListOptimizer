import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListItemNewModalComponent } from './shopping-list-item-new-modal.component';

describe('ShoppingListItemNewModalComponent', () => {
  let component: ShoppingListItemNewModalComponent;
  let fixture: ComponentFixture<ShoppingListItemNewModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListItemNewModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListItemNewModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
