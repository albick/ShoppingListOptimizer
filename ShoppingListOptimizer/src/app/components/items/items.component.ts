import {Component, OnInit} from '@angular/core';
import {EMPTY, Observable} from 'rxjs';
import {ItemQueryResponse, ShopResponse} from 'src/app/models/generated';
import {ItemService} from 'src/app/services/item.service';
import {ShopService} from 'src/app/services/shop.service';
import {NgbModal, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {ShopSelectModalComponent} from '../helpers/shop-select-modal/shop-select-modal.component';
import {faMagnifyingGlass, faShop} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
  items: Observable<ItemQueryResponse[]> = EMPTY;
  shops: Observable<ShopResponse[]> = EMPTY;
  maxItemPrice: Observable<number> = EMPTY;
  maxShopDistance: Observable<number> = EMPTY;

  form = {
    name: "",
    barcode: "",
    distance: 0,
    priceMax: 0
  }


  modalShopsRef!: NgbModalRef;

  faMagnifyingGlass = faMagnifyingGlass;
  faShop = faShop;

  constructor(private itemService: ItemService, private shopService: ShopService, private modalService: NgbModal) {

  }

  ngOnInit(): void {
    this.maxItemPrice = this.itemService.getMaxItemPrice();
    this.maxShopDistance = this.shopService.getMaxShopDistance();


    this.items = this.itemService.getItems();
  }


  onSubmit() {
    const name = this.form.name;
    const barcode = this.form.barcode;
    const distance = this.form.distance;
    const priceMax = this.form.priceMax;
    const shopIds = this.shopIds;


    this.items = this.itemService.getItems(barcode, name, distance, 0, priceMax, shopIds);
  }

  shopIds: number[] = [];

  openModalShops() {
    this.modalShopsRef = this.modalService.open(ShopSelectModalComponent);
    this.modalShopsRef.componentInstance.inputShopIds = this.shopIds;

    this.modalShopsRef.componentInstance.onDataSaved.subscribe((data: number[]) => {
      this.shopIds = data;
    });
  }
}
