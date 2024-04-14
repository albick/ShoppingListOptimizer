import { Component, Input } from '@angular/core';
import { faCircleExclamation, faPenToSquare, faTrashCan } from '@fortawesome/free-solid-svg-icons';
import {NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ShoppingListItemResponse } from 'src/app/models/generated';
import { ShoppingListItemDeleteModalComponent } from '../shopping-list-item-delete-modal/shopping-list-item-delete-modal.component';
import { ShoppingListItemEditModalComponent } from '../shopping-list-item-edit-modal/shopping-list-item-edit-modal.component';

@Component({
  selector: 'app-optimizer-list-item-row',
  templateUrl: './optimizer-list-item-row.component.html',
  styleUrls: ['./optimizer-list-item-row.component.css']
})
export class OptimizerListItemRowComponent {
  @Input() shoppingListItem!: ShoppingListItemResponse;

  faCircleExclamation = faCircleExclamation;
}
