import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable, map} from 'rxjs';
import {ItemChartResponse, ItemPriceRequest, ItemQueryResponse, ItemRequest, ItemResponse} from '../models/generated';
import {Environment} from 'src/environment/env';


const API_URL = 'https://' + Environment.apiUrl + ':7090/api/items/';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpClient) {
  }

  getItemByBarcode(barcode: string): Observable<ItemResponse> {
    return this.http.get<ItemResponse>(API_URL + barcode);
  }

  addItem(barcode: string, name: string, details: string, quantity: number, unit: string) {
    let item: ItemRequest = {
      Barcode: barcode,
      Name: name,
      Details: details,
      Quantity: quantity,
      Unit: unit
    };
    return this.http.post<ItemResponse>(API_URL, item);
  }

  addItemPrice(barcode: string, price: number, shopId: number) {
    let itemPrice: ItemPriceRequest = {
      Price: price,
      ShopId: shopId
    }
    return this.http.post<any>(API_URL + barcode, itemPrice);
  }

  getMaxItemPrice():Observable<number>{
    return this.http.get<number>(API_URL+'maxPrice');
  }

  getItems(name: string = "", distance: number = 0, priceMin: number = 0, priceMax: number = 0,shopIds:number[]=[]):Observable<ItemQueryResponse[]> {
    let query="?";
    if(name.length>0){
      query+=`name=${name}&`;
    }
    if(distance>0){
      query+=`distance=${distance}&`;
    }
    if(priceMin>0){
      query+=`priceMin=${priceMin}&`;
    }
    if(priceMax>0){
      query+=`priceMax=${priceMax}&`;
    }
    if(shopIds.length>0){
      for(let shopId of shopIds) {
        query+=`shopIds=${shopId}&`;
      }
    }

    return this.http.get<ItemQueryResponse[]>(API_URL + query);
  }

  getChartItemPriceForShops(barcode: string, shopIds: number[] = []): Observable<ItemChartResponse[]> {
    let query = '?';

    if (shopIds.length > 0) {
      for (let shopId of shopIds) {
        query += `shopIds=${shopId}&`;
      }
    }

    return this.http.get<ItemChartResponse[]>(API_URL + barcode + '/chart' + query).pipe(
      map(data => {
        // Iterate through each ItemChartResponse
        return data.map(item => {
          // Iterate through each ItemChartSeries inside the ItemChartResponse
          const updatedSeries = item.series?.map(series => {
            // Replace the 'name' property with a Date object
            return {
              ...series,
              name: new Date(series.name)
            };
          });
          // Return the updated ItemChartResponse object
          return {
            ...item,
            series: updatedSeries
          };
        });
      })
    );
  }


}
