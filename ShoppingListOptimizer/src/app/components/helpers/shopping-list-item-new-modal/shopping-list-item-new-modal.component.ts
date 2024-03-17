import {Component, Input, OnInit} from '@angular/core';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {EMPTY, Observable} from 'rxjs';
import {ShoppingListResponse} from 'src/app/models/generated';
import {ShoppingListService} from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-shopping-list-item-new-modal',
  templateUrl: './shopping-list-item-new-modal.component.html',
  styleUrls: ['./shopping-list-item-new-modal.component.css']
})
export class ShoppingListItemNewModalComponent implements OnInit {
  @Input() itemBarcode!: string;
  shoppingLists: Observable<ShoppingListResponse[]> = EMPTY;


  constructor(private modalService: NgbModal, private shoppingListService: ShoppingListService) {
  }

  ngOnInit(): void {
    this.shoppingLists=this.shoppingListService.getShoppingLists();
  }

  close() {
    this.modalService.dismissAll();
  }

  handleEvent($event: any) {
    this.shoppingListService.addShoppingListItem($event.shoppingListId,this.itemBarcode,$event.count,$event.urgent).subscribe(
      data=>{

      },error => {

      },
      ()=>{
        this.close();
      }
    )
  }
}
