import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {faPenToSquare, faSquareCheck, faTrashCan} from '@fortawesome/free-solid-svg-icons';
import {NgbModal, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {EMPTY, Observable} from 'rxjs';
import {ShoppingListResponse} from 'src/app/models/generated';
import {ShoppingListService} from 'src/app/services/shopping-list.service';
import {
  ShoppingListDeleteModalComponent
} from '../helpers/shopping-list-delete-modal/shopping-list-delete-modal.component';

@Component({
  selector: 'app-shopping-list-details',
  templateUrl: './shopping-list-details.component.html',
  styleUrls: ['./shopping-list-details.component.css']
})
export class ShoppingListDetailsComponent implements OnInit {
  id: string;

  shoppingList: Observable<ShoppingListResponse> = EMPTY;

  isEditing = false;
  isSuccessful = false;
  isEditingFailed = false;
  errorMessage = "";

  faPenToSquare = faPenToSquare;
  faTrashCan = faTrashCan;
  faSquareCheck = faSquareCheck;

  form = {
    name: "",
    details: ""
  }
  shoppingListOriginal!: ShoppingListResponse;
  nameOriginal = "";
  detailsOriginal = "";


  modalRefDelete!: NgbModalRef;

  constructor(private route: ActivatedRoute, private shoppingListService: ShoppingListService, private modalService: NgbModal) {
    this.id = this.route.snapshot.paramMap.get('id') ?? "";
  }

  ngOnInit(): void {
    this.shoppingList = this.shoppingListService.getShoppingList(this.id);
    this.shoppingList.subscribe(data => {
      this.shoppingListOriginal = data;
      this.form = {
        name: data.name,
        details: data.details
      };
    })
  }

  cancel() {
    this.isEditing = !this.isEditing;
    this.form.name = this.nameOriginal;
    this.form.details = this.detailsOriginal;
  }

  save() {
    this.isEditing = !this.isEditing;
    const {name, details} = this.form;
    this.shoppingListService.updateShoppingList(this.id, name, details).subscribe();
    window.location.reload();
  }

  edit() {
    this.nameOriginal = this.form.name;
    this.detailsOriginal = this.form.details;
    this.isEditing = !this.isEditing;
  }

  delete() {
    this.modalRefDelete = this.modalService.open(ShoppingListDeleteModalComponent);
    this.modalRefDelete.componentInstance.shoppingList = this.shoppingListOriginal;
  }
}
