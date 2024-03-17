import {Component, Input} from '@angular/core';
import {Router} from '@angular/router';
import {faCircleInfo, faTrashCan} from '@fortawesome/free-solid-svg-icons';
import {NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import {ShoppingListResponse} from 'src/app/models/generated';
import { ShoppingListDeleteModalComponent } from '../shopping-list-delete-modal/shopping-list-delete-modal.component';

@Component({
  selector: 'app-shopping-list-row',
  templateUrl: './shopping-list-row.component.html',
  styleUrls: ['./shopping-list-row.component.css']
})
export class ShoppingListRowComponent {
  @Input() shoppingList!: ShoppingListResponse;

  faCircleInfo = faCircleInfo;
  faTrashCan = faTrashCan;
  modalRef!: NgbModalRef;
  constructor(private router: Router,private modalService: NgbModal) {
  }
  openModal() {
    this.modalRef = this.modalService.open(ShoppingListDeleteModalComponent);
    this.modalRef.componentInstance.shoppingList = this.shoppingList;
  }

}
