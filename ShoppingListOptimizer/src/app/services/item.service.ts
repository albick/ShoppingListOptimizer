import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ItemResponse } from '../models/generated';


const API_URL = 'https://localhost:7090/api/items/';
@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpClient) {
  }
  getItemByBarcode(barcode:string):Observable<ItemResponse>{
    return this.http.get<ItemResponse>(API_URL);
  }
}
