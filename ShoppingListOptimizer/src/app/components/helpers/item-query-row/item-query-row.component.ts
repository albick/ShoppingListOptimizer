import { Component, Input } from '@angular/core';
import { ItemQueryResponse } from 'src/app/models/generated';



@Component({
  selector: 'app-item-query-row',
  templateUrl: './item-query-row.component.html',
  styleUrls: ['./item-query-row.component.css']
})
export class ItemQueryRowComponent {
  @Input() item!: ItemQueryResponse;

}
