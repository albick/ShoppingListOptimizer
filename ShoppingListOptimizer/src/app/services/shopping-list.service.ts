import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {ShoppingListItemRequest, ShoppingListItemResponse, ShoppingListRequest, ShoppingListResponse} from '../models/generated';
import {Observable} from 'rxjs';
import { Environment } from 'src/environment/env';


const API_URL = 'https://'+Environment.apiUrl+':7090/api/shoppinglists/';
@Injectable({
  providedIn: 'root'
})
export class ShoppingListService {

  constructor(private http: HttpClient) {
  }

  addShoppingList(name:string,details:string): Observable<ShoppingListResponse> {
    let shoppingList:ShoppingListRequest={
      Name:name,
      Details:details
    };
    return this.http.post<ShoppingListResponse>(API_URL,shoppingList);
  }

  updateShoppingList(id:string,name:string,details:string): Observable<ShoppingListResponse> {
    let shoppingList:ShoppingListRequest={
      Name:name,
      Details:details
    };
    return this.http.put<ShoppingListResponse>(API_URL+`${id}`,shoppingList);
  }

  deleteShoppingList(id:string): Observable<boolean> {
    return this.http.delete<boolean>(API_URL+`${id}`);
  }

  getShoppingLists(): Observable<ShoppingListResponse[]> {
    return this.http.get<ShoppingListResponse[]>(API_URL);
  }

  getShoppingList(id:string): Observable<ShoppingListResponse> {
    return this.http.get<ShoppingListResponse>(API_URL+`${id}`);
  }

  deleteShoppingListItem(listId:string,itemId:string): Observable<boolean> {
    return this.http.delete<boolean>(API_URL+`${listId}/items/${itemId}`);
  }

  addShoppingListItem(listId:string,itemId:string,count:number,isPriority:boolean): Observable<ShoppingListItemResponse> {
    let shoppingListItem:ShoppingListItemRequest={
      ItemId:itemId,
      Count:count,
      IsPriority: isPriority
    };
    return this.http.post<ShoppingListItemResponse>(API_URL+`${listId}/items`,shoppingListItem);
  }

  updateShoppingListItem(listId:string,listItemId:string,itemId:string,count:number,isPriority:boolean): Observable<ShoppingListItemResponse> {
    let shoppingListItem:ShoppingListItemRequest={
      ItemId:itemId,
      Count:count,
      IsPriority: isPriority
    };
    return this.http.put<ShoppingListItemResponse>(API_URL+`${listId}/items/${listItemId}`,shoppingListItem);
  }
}
