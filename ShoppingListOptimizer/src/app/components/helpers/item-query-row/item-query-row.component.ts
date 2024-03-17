import {Component, Input} from '@angular/core';
import {Router} from '@angular/router';
import {faBasketShopping, faCircleInfo} from '@fortawesome/free-solid-svg-icons';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import {ItemQueryResponse} from 'src/app/models/generated';
import { ShoppingListItemNewModalComponent } from '../shopping-list-item-new-modal/shopping-list-item-new-modal.component';


@Component({
  selector: 'app-item-query-row',
  templateUrl: './item-query-row.component.html',
  styleUrls: ['./item-query-row.component.css']
})
export class ItemQueryRowComponent {
  @Input() item!: ItemQueryResponse;

  faCircleInfo = faCircleInfo;
  faBasketShopping = faBasketShopping;

  modalRef!: NgbModalRef;
  constructor(private router: Router,private modalService: NgbModal) {
  }

  reloadPageAndRedirect(): void {
    // Navigate to the desired route
    this.router.navigate(['/items/' + this.item.itemBarcode + '/' + this.item.shopId]);

    // Reload the page after a short delay (e.g., 500 milliseconds)
    setTimeout(() => {
      window.location.reload();
    }, 200);
  }

  openModal() {
    this.modalRef = this.modalService.open(ShoppingListItemNewModalComponent);
    this.modalRef.componentInstance.itemBarcode = this.item.itemBarcode;
  }
}
