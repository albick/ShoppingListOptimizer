import {Component, ElementRef, OnInit} from '@angular/core';
import {EMPTY, Observable} from 'rxjs';
import {ItemQueryResponse, ShopResponse} from 'src/app/models/generated';
import {ItemService} from 'src/app/services/item.service';
import {ShopService} from 'src/app/services/shop.service';
import {NgbModal, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {ShopSelectModalComponent} from '../helpers/shop-select-modal/shop-select-modal.component';
import {faMagnifyingGlass, faShop} from '@fortawesome/free-solid-svg-icons';
import * as L from 'leaflet';

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

  mapShops!:ShopResponse[];
  mapShopIds:string[]=[];

  form = {
    name: "",
    barcode: "",
    distance: 0,
    priceMax: 0
  }

  mapResultsPage = false;

  modalShopsRef!: NgbModalRef;

  faMagnifyingGlass = faMagnifyingGlass;
  faShop = faShop;

  constructor(private itemService: ItemService, private shopService: ShopService, private modalService: NgbModal, private elementRef: ElementRef) {

  }

  ngOnInit(): void {
    this.maxItemPrice = this.itemService.getMaxItemPrice();
    this.maxShopDistance = this.shopService.getMaxShopDistance();


    this.items = this.itemService.getItems();
    this.items.subscribe(data=>{
      data.forEach(response => {
        if (!this.mapShopIds.includes(response.shopId)) {
          this.mapShopIds.push(response.shopId);
        }
      });
    })
  }


  onSubmit() {
    const name = this.form.name;
    const barcode = this.form.barcode;
    const distance = this.form.distance;
    const priceMax = this.form.priceMax;
    const shopIds = this.shopIds;


    this.items = this.itemService.getItems(barcode, name, distance, 0, priceMax, shopIds);
    const mapElement = this.elementRef.nativeElement.querySelector('#shop_map');
    this.initMap(mapElement);
  }

  shopIds: number[] = [];

  openModalShops() {
    this.modalShopsRef = this.modalService.open(ShopSelectModalComponent);
    this.modalShopsRef.componentInstance.inputShopIds = this.shopIds;

    this.modalShopsRef.componentInstance.onDataSaved.subscribe((data: number[]) => {
      this.shopIds = data;
    });
  }

  mapResultsPageClicked(alreadyThere: boolean) {
    if (alreadyThere) {
      this.mapResultsPage = true;
    } else {
      this.mapResultsPage=false;
    }
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      const mapElement = this.elementRef.nativeElement.querySelector('#shop_map');
      if (mapElement) {
        this.initMap(mapElement);
      } else {
        console.error('Map container not found.');
      }
    }, 500);
  }

  initMap(mapElement: HTMLElement): void {
    console.log(this.mapShopIds);

    const isRetina = L.Browser.retina;
    //const map = L.map(mapElement).setView([this.shopLatitude, this.shopLongitude], 16);



    const map = L.map(mapElement).setView([ 47.45493875, 18.943733936449245], 16);
    const myAPIKey = "d69bf89b9e5c4838bc7dd0cf2ede270a";
    const baseUrl = `https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}.png?apiKey=${myAPIKey}`;
    const retinaUrl = `https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}@2x.png?apiKey=${myAPIKey}`;
    L.tileLayer(isRetina ? retinaUrl : baseUrl, {
      maxZoom: 20,
      id: 'osm-bright'
    }).addTo(map);


    const svgIconDataUri = 'data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA1NzYgNTEyIj48IS0tIUZvbnQgQXdlc29tZSBGcmVlIDYuNS4xIGJ5IEBmb250YXdlc29tZSAtIGh0dHBzOi8vZm9udGF3ZXNvbWUuY29tIExpY2Vuc2UgLSBodHRwczovL2ZvbnRhd2Vzb21lLmNvbS9saWNlbnNlL2ZyZWUgQ29weXJpZ2h0IDIwMjQgRm9udGljb25zLCBJbmMuLS0+PHBhdGggZD0iTTI1My4zIDM1LjFjNi4xLTExLjggMS41LTI2LjMtMTAuMi0zMi40cy0yNi4zLTEuNS0zMi40IDEwLjJMMTE3LjYgMTkySDMyYy0xNy43IDAtMzIgMTQuMy0zMiAzMnMxNC4zIDMyIDMyIDMyTDgzLjkgNDYzLjVDOTEgNDkyIDExNi42IDUxMiAxNDYgNTEySDQzMGMyOS40IDAgNTUtMjAgNjIuMS00OC41TDU0NCAyNTZjMTcuNyAwIDMyLTE0LjMgMzItMzJzLTE0LjMtMzItMzItMzJINDU4LjRMMzY1LjMgMTIuOUMzNTkuMiAxLjIgMzQ0LjctMy40IDMzMi45IDIuN3MtMTYuMyAyMC42LTEwLjIgMzIuNEw0MDQuMyAxOTJIMTcxLjdMMjUzLjMgMzUuMXpNMTkyIDMwNHY5NmMwIDguOC03LjIgMTYtMTYgMTZzLTE2LTcuMi0xNi0xNlYzMDRjMC04LjggNy4yLTE2IDE2LTE2czE2IDcuMiAxNiAxNnptOTYtMTZjOC44IDAgMTYgNy4yIDE2IDE2djk2YzAgOC44LTcuMiAxNi0xNiAxNnMtMTYtNy4yLTE2LTE2VjMwNGMwLTguOCA3LjItMTYgMTYtMTZ6bTEyOCAxNnY5NmMwIDguOC03LjIgMTYtMTYgMTZzLTE2LTcuMi0xNi0xNlYzMDRjMC04LjggNy4yLTE2IDE2LTE2czE2IDcuMiAxNiAxNnoiLz48L3N2Zz4=';

    let customIcon = L.divIcon({
      html: `<img src="${svgIconDataUri}" width="32" height="32">`,
      iconSize: [32, 32],
      className: "div-icon"
    });

    //L.marker([this.shopLatitude, this.shopLongitude], {icon: customIcon}).addTo(map)
    L.marker([47.45493875,18.943733936449245], {icon: customIcon}).addTo(map)
  }
}
