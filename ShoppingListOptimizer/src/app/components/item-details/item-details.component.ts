import {Component} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {NgbModal, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {Color, NgxChartsModule} from '@swimlane/ngx-charts';
import {EMPTY, Observable} from 'rxjs';
import {ItemChartResponse, ItemQueryResponse, ItemResponse} from 'src/app/models/generated';
import {ItemService} from 'src/app/services/item.service';
import {ShopSelectModalComponent} from '../helpers/shop-select-modal/shop-select-modal.component';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent {
  id: string = "";
  shopId: string = "";
  item: Observable<ItemResponse> = EMPTY;

  constructor(private route: ActivatedRoute, private itemService: ItemService, private modalService: NgbModal) {
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
    console.log("shopId:"+this.shopId)
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
