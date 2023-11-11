import { Component, Input } from '@angular/core';
import { ShopResponse } from 'src/app/models/generated';

@Component({
  selector: 'app-shop-row',
  templateUrl: './shop-row.component.html',
  styleUrls: ['./shop-row.component.css']
})
export class ShopRowComponent {
  @Input() shop!: ShopResponse;

  constructor() {

  }
}
