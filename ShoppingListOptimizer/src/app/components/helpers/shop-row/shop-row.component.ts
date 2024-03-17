import {Component, Input} from '@angular/core';
import {faCircleInfo} from '@fortawesome/free-solid-svg-icons';
import {ShopResponse} from 'src/app/models/generated';

@Component({
  selector: 'app-shop-row',
  templateUrl: './shop-row.component.html',
  styleUrls: ['./shop-row.component.css']
})
export class ShopRowComponent {
  @Input() shop!: ShopResponse;

  faCircleInfo = faCircleInfo;

  constructor() {

  }
}
