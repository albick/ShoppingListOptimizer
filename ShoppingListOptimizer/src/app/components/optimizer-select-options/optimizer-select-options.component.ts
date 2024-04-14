import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {faMicroscope} from '@fortawesome/free-solid-svg-icons';
import {EMPTY, Observable} from 'rxjs';
import {ShoppingListResponse} from 'src/app/models/generated';
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

  form = {
    distance: 0,
    onlyOptimizePriority: false
  }

  faMicroscope = faMicroscope;
  showLoading=false;
  loadingProgress=0;

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
    const {distance, onlyOptimizePriority} = this.form;

    // Set showLoading to true to start the spinner
    this.showLoading = true;

    // Reset loadingProgress
    this.loadingProgress = 0;

    // Start increasing loadingProgress gradually
    const intervalId = setInterval(() => {
      if (this.loadingProgress < 100) {
        this.loadingProgress++;
      }
    }, 30); // Increase by 1 every 30ms to reach 100 in about 3000ms

    this.shoppingListService.optimizeShoppingList(this.id, distance, onlyOptimizePriority).subscribe(data => {
        // Stop increasing loadingProgress when API call returns
        clearInterval(intervalId);
        this.loadingProgress = 100;
        console.log(data)
        //this.showLoading = false;
      },
      err => {
        // Stop increasing loadingProgress in case of error
        clearInterval(intervalId);
        this.loadingProgress = 100;
        //this.showLoading = false;
      });

    // Ensure loadingProgress reaches 100 in at least 3000ms
    setTimeout(() => {
      clearInterval(intervalId);
      this.loadingProgress = 100;
    }, 3000);
  }


}
