import {Component} from '@angular/core';
import {faSquarePlus} from '@fortawesome/free-solid-svg-icons';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ShoppingListService} from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-shopping-list-new-modal',
  templateUrl: './shopping-list-new-modal.component.html',
  styleUrls: ['./shopping-list-new-modal.component.css']
})
export class ShoppingListNewModalComponent {

  isSuccessful=false;
  errorMessage = "";
  isAddFailed=false;

  form: any = {
    name: "",
    details: ""
  };

  faSquarePlus = faSquarePlus;

  constructor(private modalService: NgbModal, private shoppingListService: ShoppingListService) {
  }

  close() {
    this.modalService.dismissAll();
  }

  add() {
    //this.shoppingListService
    this.modalService.dismissAll();
    window.location.reload();
  }

  onSubmit() {
    const {name, details} = this.form;
    this.shoppingListService.addShoppingList(name, details).subscribe(data => {
      this.modalService.dismissAll();
      window.location.reload();
    }, error => {
      this.errorMessage=error.error;
      this.isAddFailed=true;
      this.isSuccessful=false;
    })
  }
}
