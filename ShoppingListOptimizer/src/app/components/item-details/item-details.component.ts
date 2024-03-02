import {Component, ElementRef} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {NgbModal, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {Color, NgxChartsModule} from '@swimlane/ngx-charts';
import {EMPTY, Observable, switchMap} from 'rxjs';
import {ItemChartResponse, ItemQueryResponse, ItemResponse, ShopResponse} from 'src/app/models/generated';
import {ItemService} from 'src/app/services/item.service';
import {ShopSelectModalComponent} from '../helpers/shop-select-modal/shop-select-modal.component';
import {ShopService} from 'src/app/services/shop.service';
import * as L from 'leaflet';
import {IconDefinition, faShoppingBasket} from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent {
  id: string = "";
  shopId: string = "";
  shop: Observable<ShopResponse> = EMPTY;
  item: Observable<ItemResponse> = EMPTY;

  shopLatitude = 0;
  shopLongitude = 0;


  constructor(private route: ActivatedRoute, private itemService: ItemService, private shopService: ShopService, private modalService: NgbModal, private elementRef: ElementRef) {
    /*this.route.params.subscribe(params => {
      this.id = params['id'];
    });*/
    this.id = this.route.snapshot.paramMap.get('id') ?? "";
    this.shopId = this.route.snapshot.paramMap.get('shopId') ?? "";
  }

  ngOnInit(): void {
    this.itemPriceAllShops = this.itemService.getChartItemPriceForShops(this.id);
    this.item = this.itemService.getItemByBarcode(this.id);
    this.items = this.itemService.getItems(this.id);
    this.shop = this.shopService.getShop(this.shopId);
    this.shop.subscribe(shop => {
      //do stg with coordinates
      this.shopLongitude = shop.location.longitude;
      this.shopLatitude = shop.location.latitude;
    })

  }


  itemPriceAllShops: Observable<ItemChartResponse[]> = EMPTY;
  itemPriceSelectedShops: Observable<ItemChartResponse[]> = EMPTY;
  items: Observable<ItemQueryResponse[]> = EMPTY;


  view: [number, number] = [700, 300];

  // options
  legend: boolean = false;
  showLabels: boolean = true;
  animations: boolean = false;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Date';
  yAxisLabel: string = 'Price';
  timeline: boolean = false;

  shopIds: number[] = [];
  modalRef!: NgbModalRef;

  ngAfterViewInit(): void {
    setTimeout(() => {
      const mapElement = this.elementRef.nativeElement.querySelector('#shop_map');
      if (mapElement) {
        // Map element found, proceed with initialization
        this.initMap(mapElement);
      } else {
        console.error('Map container not found.');
      }
    }, 500); // Wait for 0.5 seconds before trying to select the element
  }


  initMap(mapElement: HTMLElement): void {
    // Your map initialization code here
    console.log('Map element:', mapElement);
    const isRetina = L.Browser.retina;
    const map = L.map(mapElement).setView([this.shopLatitude, this.shopLongitude], 16);
    const myAPIKey = "d69bf89b9e5c4838bc7dd0cf2ede270a";
    const baseUrl = `https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}.png?apiKey=${myAPIKey}`;
    const retinaUrl = `https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}@2x.png?apiKey=${myAPIKey}`;
    L.tileLayer(isRetina ? retinaUrl : baseUrl, {
      attribution: 'Powered by <a href="https://www.geoapify.com/" target="_blank">Geoapify</a> | <a href="https://openmaptiles.org/" target="_blank">© OpenMapTiles</a> <a href="https://www.openstreetmap.org/copyright" target="_blank">© OpenStreetMap</a> contributors',
      maxZoom: 20,
      id: 'osm-bright'
    }).addTo(map);

    const svgIconDataUri = 'data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA1NzYgNTEyIj48IS0tIUZvbnQgQXdlc29tZSBGcmVlIDYuNS4xIGJ5IEBmb250YXdlc29tZSAtIGh0dHBzOi8vZm9udGF3ZXNvbWUuY29tIExpY2Vuc2UgLSBodHRwczovL2ZvbnRhd2Vzb21lLmNvbS9saWNlbnNlL2ZyZWUgQ29weXJpZ2h0IDIwMjQgRm9udGljb25zLCBJbmMuLS0+PHBhdGggZD0iTTI1My4zIDM1LjFjNi4xLTExLjggMS41LTI2LjMtMTAuMi0zMi40cy0yNi4zLTEuNS0zMi40IDEwLjJMMTE3LjYgMTkySDMyYy0xNy43IDAtMzIgMTQuMy0zMiAzMnMxNC4zIDMyIDMyIDMyTDgzLjkgNDYzLjVDOTEgNDkyIDExNi42IDUxMiAxNDYgNTEySDQzMGMyOS40IDAgNTUtMjAgNjIuMS00OC41TDU0NCAyNTZjMTcuNyAwIDMyLTE0LjMgMzItMzJzLTE0LjMtMzItMzItMzJINDU4LjRMMzY1LjMgMTIuOUMzNTkuMiAxLjIgMzQ0LjctMy40IDMzMi45IDIuN3MtMTYuMyAyMC42LTEwLjIgMzIuNEw0MDQuMyAxOTJIMTcxLjdMMjUzLjMgMzUuMXpNMTkyIDMwNHY5NmMwIDguOC03LjIgMTYtMTYgMTZzLTE2LTcuMi0xNi0xNlYzMDRjMC04LjggNy4yLTE2IDE2LTE2czE2IDcuMiAxNiAxNnptOTYtMTZjOC44IDAgMTYgNy4yIDE2IDE2djk2YzAgOC44LTcuMiAxNi0xNiAxNnMtMTYtNy4yLTE2LTE2VjMwNGMwLTguOCA3LjItMTYgMTYtMTZ6bTEyOCAxNnY5NmMwIDguOC03LjIgMTYtMTYgMTZzLTE2LTcuMi0xNi0xNlYzMDRjMC04LjggNy4yLTE2IDE2LTE2czE2IDcuMiAxNiAxNnoiLz48L3N2Zz4=';

// Define a custom icon using the SVG data URI
    let customIcon = L.divIcon({
      html: `<img src="${svgIconDataUri}" width="32" height="32">`, // Add inline style to remove background
      iconSize: [32, 32], // Adjust icon size as needed
      className:"div-icon"
    });

    L.marker([this.shopLatitude, this.shopLongitude],{ icon:  customIcon}).addTo(map)
  }







  openModal() {
    this.modalRef = this.modalService.open(ShopSelectModalComponent);
    this.modalRef.componentInstance.inputShopIds = this.shopIds;

    // Subscribe to onDataSaved event to receive data from modal
    this.modalRef.componentInstance.onDataSaved.subscribe((data: number[]) => {
      // Handle data received from modal
      this.shopIds = data;
      if (this.shopIds.length > 0) {
        this.itemPriceSelectedShops = this.itemService.getChartItemPriceForShops(this.id, this.shopIds);
      } else {
        this.itemPriceSelectedShops = EMPTY;
      }
    });
  }
}
