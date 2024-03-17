import { Component, EventEmitter, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EMPTY, Observable } from 'rxjs';
import { ShopResponse } from 'src/app/models/generated';
import { ShopService } from 'src/app/services/shop.service';
@Component({
  selector: 'app-shop-select-modal',
  templateUrl: './shop-select-modal.component.html',
  styleUrls: ['./shop-select-modal.component.css']
})
export class ShopSelectModalComponent {
  @Input() inputShopIds!:number[];
  data: number[]=[];
  shops:Observable<ShopResponse[]> = EMPTY;
  constructor(private modalService: NgbModal,private shopService:ShopService) {}

  ngOnInit() {
    this.shops=this.shopService.getShops();
    this.data= this.inputShopIds;
  }
  open(content: any) {
    this.modalService.open(content);
  }

  close(){
    this.saveData();
    this.modalService.dismissAll();
  }


  onDataSaved = new EventEmitter<any>();

  saveData() {
    this.onDataSaved.emit(this.data);
  }

  clickCheckbox($event: any) {
    if ($event.target.checked && !this.data.includes(Number($event.target.id))) {
      this.data.push(Number($event.target.id));
    } else if (!$event.target.checked && this.data.includes(Number($event.target.id))) {
      this.data = this.data.filter(id => id !== Number($event.target.id));
    }
  }
}
