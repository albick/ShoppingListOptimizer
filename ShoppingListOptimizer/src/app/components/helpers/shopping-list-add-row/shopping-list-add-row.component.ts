import {Component, EventEmitter, Input, Output} from '@angular/core';
import {faSquareCheck} from '@fortawesome/free-solid-svg-icons';
import {ShoppingListResponse} from 'src/app/models/generated';

@Component({
  selector: 'app-shopping-list-add-row',
  templateUrl: './shopping-list-add-row.component.html',
  styleUrls: ['./shopping-list-add-row.component.css']
})
export class ShoppingListAddRowComponent {
  @Input() shoppingList!: ShoppingListResponse;
  @Input() itemBarcode!: string;

  @Output() onSave = new EventEmitter<any>();

  faSquareCheck = faSquareCheck;


  data={
    urgent:false,
    count:0,
    shoppingListId:0
  }

  save() {
    this.data.shoppingListId=this.shoppingList.id;
    this.onSave.emit(this.data);
  }
}
