import {Component} from '@angular/core';
import {EMPTY, Observable} from 'rxjs';
import {ShopResponse} from 'src/app/models/generated';
import {ShopService} from 'src/app/services/shop.service';

@Component({
  selector: 'app-shops',
  templateUrl: './shops.component.html',
  styleUrls: ['./shops.component.css']
})
export class ShopsComponent {

  shops: Observable<ShopResponse[]> = EMPTY;

  constructor(private shopService: ShopService) {

  }

  ngOnInit(): void {
    this.shops = this.shopService.getShops();
    this.shops.subscribe(data=>{
      console.log(data)
    })
  }
}
