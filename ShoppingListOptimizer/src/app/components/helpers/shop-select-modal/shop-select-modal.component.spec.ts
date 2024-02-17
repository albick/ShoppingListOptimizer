import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopSelectModalComponent } from './shop-select-modal.component';

describe('ShopSelectModalComponent', () => {
  let component: ShopSelectModalComponent;
  let fixture: ComponentFixture<ShopSelectModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopSelectModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShopSelectModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
