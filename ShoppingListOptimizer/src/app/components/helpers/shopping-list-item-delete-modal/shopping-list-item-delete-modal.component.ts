import {Component, Input} from '@angular/core';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ShoppingListItemResponse} from 'src/app/models/generated';
import {ShoppingListService} from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-shopping-list-item-delete-modal',
  templateUrl: './shopping-list-item-delete-modal.component.html',
  styleUrls: ['./shopping-list-item-delete-modal.component.css']
})
export class ShoppingListItemDeleteModalComponent {
  @Input() shoppingListItem!: ShoppingListItemResponse;
  @Input() shoppingListId!:number;

  constructor(private modalService: NgbModal, private shoppingListService: ShoppingListService) {
  }

  close() {
    this.modalService.dismissAll();
  }

  delete() {
    this.shoppingListService.deleteShoppingListItem(this.shoppingListId.toString(),this.shoppingListItem.id.toString()).subscribe();
    this.modalService.dismissAll();
    window.location.reload();
  }
}
