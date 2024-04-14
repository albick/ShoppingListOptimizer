import { Component, Input } from '@angular/core';
import { faCircleInfo, faMicroscope } from '@fortawesome/free-solid-svg-icons';
import { ShoppingListResponse } from 'src/app/models/generated';

@Component({
  selector: 'app-optimizer-list-row',
  templateUrl: './optimizer-list-row.component.html',
  styleUrls: ['./optimizer-list-row.component.css']
})
export class OptimizerListRowComponent {
  @Input() shoppingList!: ShoppingListResponse;
  faCircleInfo=faCircleInfo;
  faMicroscope=faMicroscope;
}
