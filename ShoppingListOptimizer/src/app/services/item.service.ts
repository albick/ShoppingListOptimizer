import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {ItemPriceRequest, ItemRequest, ItemResponse } from '../models/generated';
import { Environment } from 'src/environment/env';


const API_URL = 'https://'+Environment.apiUrl+':7090/api/items/';
@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpClient) {
  }
  getItemByBarcode(barcode:string):Observable<ItemResponse>{
    return this.http.get<ItemResponse>(API_URL + barcode);
  }

  addItem(barcode:string,name:string,details:string,quantity:number,unit:string){
    let item:ItemRequest={
      Barcode:barcode,
      Name:name,
      Details:details,
      Quantity:quantity,
      Unit:unit
    };
    return this.http.post<ItemResponse>(API_URL,item);
  }

  addItemPrice(barcode:string,price:number,shopId:string){
    let itemPrice:ItemPriceRequest={
      Price:price,
      ShopId:shopId
    }
    return this.http.post<any>(API_URL+barcode,itemPrice);
  }
}
