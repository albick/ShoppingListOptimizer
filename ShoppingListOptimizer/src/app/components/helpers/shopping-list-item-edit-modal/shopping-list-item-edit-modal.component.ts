import { Component, Input, OnInit } from '@angular/core';
import { faSquareCheck } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ShoppingListItemResponse } from 'src/app/models/generated';
import { ShoppingListService } from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-shopping-list-item-edit-modal',
  templateUrl: './shopping-list-item-edit-modal.component.html',
  styleUrls: ['./shopping-list-item-edit-modal.component.css']
})
export class ShoppingListItemEditModalComponent implements OnInit{
  @Input() shoppingListItem!: ShoppingListItemResponse;
  @Input() shoppingListId!:number;

  faSquareCheck=faSquareCheck;

  isSuccessful=false;
  errorMessage = "";
  isAddFailed=false;

  form: any = {
    count: 1,
    urgent: true
  };

  constructor(private modalService: NgbModal, private shoppingListService: ShoppingListService) {
  }

  ngOnInit(): void {
    this.form={
      count:this.shoppingListItem.count,
      urgent:this.shoppingListItem.isPriority
    }
  }


  close() {
    this.modalService.dismissAll();
  }

  edit() {
    const {count,urgent}=this.form;
    this.shoppingListService.updateShoppingListItem(this.shoppingListId.toString(),this.shoppingListItem.id.toString(),this.shoppingListItem.itemId,count,urgent).subscribe();
    this.modalService.dismissAll();
    window.location.reload();
  }
}
