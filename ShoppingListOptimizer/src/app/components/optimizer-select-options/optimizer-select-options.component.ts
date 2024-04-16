import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {faMicroscope} from '@fortawesome/free-solid-svg-icons';
import {EMPTY, Observable} from 'rxjs';
import {ShopOptimizationResponse, ShoppingListResponse} from 'src/app/models/generated';
import {ShopService} from 'src/app/services/shop.service';
import {ShoppingListService} from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-optimizer-select-options',
  templateUrl: './optimizer-select-options.component.html',
  styleUrls: ['./optimizer-select-options.component.css']
})
export class OptimizerSelectOptionsComponent implements OnInit {
  id: string;
  shoppingList: Observable<ShoppingListResponse> = EMPTY;
  maxShopDistance: Observable<number> = EMPTY;

  countPriority = 0;

  isSubmitted=false;
  shopOptimizationResponse: Observable<ShopOptimizationResponse[]> =EMPTY;

  form = {
    distance: 0,
    selectedMode: 0,
    openNow: false
  }

  faMicroscope = faMicroscope;
  showLoading = false;
  loadingProgress = 0;

  constructor(private route: ActivatedRoute, private shoppingListService: ShoppingListService, private shopService: ShopService) {
    this.id = this.route.snapshot.paramMap.get('id') ?? "";
  }

  ngOnInit(): void {
    this.maxShopDistance = this.shopService.getMaxShopDistance();
    this.shoppingList = this.shoppingListService.getShoppingList(this.id);
    this.shoppingList.subscribe(data => {
      this.countPriority = data.shoppingListItems.filter(item => item.isPriority).length;
    })
  }

  submit() {
    this.isSubmitted=true;
    const {distance, selectedMode, openNow} = this.form;


    this.shopOptimizationResponse=this.shoppingListService.optimizeShoppingList(this.id, distance, selectedMode, openNow);
  }

  //selectedMode:Number=0;
  modeClicked(mode: number) {
    if (mode != this.form.selectedMode) {
      this.form.selectedMode = mode;
    }
  }


}
