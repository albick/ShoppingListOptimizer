import {Component, OnInit} from '@angular/core';
import { faReceipt } from '@fortawesome/free-solid-svg-icons';
import {NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import {EMPTY, Observable} from 'rxjs';
import {ShoppingListResponse} from 'src/app/models/generated';
import { ShoppingListService } from 'src/app/services/shopping-list.service';
import { ShoppingListNewModalComponent } from '../helpers/shopping-list-new-modal/shopping-list-new-modal.component';

@Component({
  selector: 'app-shopping-lists',
  templateUrl: './shopping-lists.component.html',
  styleUrls: ['./shopping-lists.component.css']
})
export class ShoppingListsComponent implements OnInit {
  shoppingLists: Observable<ShoppingListResponse[]> = EMPTY;

  faReceipt=faReceipt;

  modalRef!: NgbModalRef;
  constructor(private shoppingListService:ShoppingListService, private modalService: NgbModal) {
  }

  ngOnInit(): void {
    this.shoppingLists =this.shoppingListService.getShoppingLists();
  }

  openModalNewShoppingList() {
    this.modalRef = this.modalService.open(ShoppingListNewModalComponent);
  }
}
