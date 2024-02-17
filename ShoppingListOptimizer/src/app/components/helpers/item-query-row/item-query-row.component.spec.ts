import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemQueryRowComponent } from './item-query-row.component';

describe('ItemQueryRowComponent', () => {
  let component: ItemQueryRowComponent;
  let fixture: ComponentFixture<ItemQueryRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemQueryRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemQueryRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
