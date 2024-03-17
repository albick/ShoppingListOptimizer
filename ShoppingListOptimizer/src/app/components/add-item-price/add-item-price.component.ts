import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {faHouse, faTag } from '@fortawesome/free-solid-svg-icons';
import {EMPTY, Observable} from 'rxjs';
import {ShopResponse} from 'src/app/models/generated';
import { ItemService } from 'src/app/services/item.service';
import { ShopService } from 'src/app/services/shop.service';

@Component({
  selector: 'app-add-item-price',
  templateUrl: './add-item-price.component.html',
  styleUrls: ['./add-item-price.component.css']
})
export class AddItemPriceComponent implements OnInit {
  id: string = "";
  form: any = {
    barcode: "",
    shopId: "",
    price: 0
  };

  isSuccessful: any;
  errorMessage = "";

  shops: Observable<ShopResponse[]> = EMPTY;
  isAddFailed: any;

  faTag=  faTag;
  faHouse=  faHouse;

  constructor(private route: ActivatedRoute,private shopService:ShopService,private itemService:ItemService) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
  }

  ngOnInit(): void {
    this.form.barcode = this.id;
    this.shops=this.shopService.getShops();
  }

  onSubmit() {
    const { barcode, price } = this.form;
    const shopId = this.form.shop;
    this.itemService.addItemPrice(barcode,price,shopId).subscribe(data=>{
      console.log(data)
      this.isAddFailed=false;
      this.isSuccessful=true;
    },error => {
      this.errorMessage=error.error;
      this.isAddFailed=true;
      console.log(error.error)
    });
  }
}
