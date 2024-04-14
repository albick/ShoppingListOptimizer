import { Component, OnInit } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { ShoppingListResponse } from 'src/app/models/generated';
import { ShoppingListService } from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-optimizer-lists',
  templateUrl: './optimizer-lists.component.html',
  styleUrls: ['./optimizer-lists.component.css']
})
export class OptimizerListsComponent implements OnInit {
  shoppingLists: Observable<ShoppingListResponse[]> = EMPTY;
  constructor(private shoppingListService:ShoppingListService) {
  }
  ngOnInit(): void {
    this.shoppingLists =this.shoppingListService.getShoppingLists();
  }
}
