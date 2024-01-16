import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddItemPriceComponent } from './add-item-price.component';

describe('AddItemPriceComponent', () => {
  let component: AddItemPriceComponent;
  let fixture: ComponentFixture<AddItemPriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddItemPriceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddItemPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
