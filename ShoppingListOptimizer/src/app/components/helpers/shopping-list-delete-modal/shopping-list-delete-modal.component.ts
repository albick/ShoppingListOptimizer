import {Component, Input} from '@angular/core';
import {Router} from '@angular/router';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ShoppingListResponse} from 'src/app/models/generated';
import {ShoppingListService} from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-shopping-list-delete-modal',
  templateUrl: './shopping-list-delete-modal.component.html',
  styleUrls: ['./shopping-list-delete-modal.component.css']
})
export class ShoppingListDeleteModalComponent {
  @Input() shoppingList!: ShoppingListResponse;

  constructor(private modalService: NgbModal, private shoppingListService: ShoppingListService, private router: Router) {
  }

  close() {
    this.modalService.dismissAll();
  }

  delete() {
    this.shoppingListService.deleteShoppingList(this.shoppingList.id.toString()).subscribe();
    this.modalService.dismissAll();
    this.router.navigate(['shopping-lists']);
    window.location.reload();
  }
}
