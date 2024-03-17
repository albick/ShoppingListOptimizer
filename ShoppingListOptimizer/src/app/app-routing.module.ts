import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from "./components/login/login.component";
import {RegisterComponent} from "./components/register/register.component";
import { RegisterShopComponent } from './components/register-shop/register-shop.component';
import { HomeComponent } from './components/home/home.component';
import { AddShopComponent } from './components/add-shop/add-shop.component';
import { ShopsComponent } from './components/shops/shops.component';
import { ScanBarcodeComponent } from './components/scan-barcode/scan-barcode.component';
import { AddItemPriceComponent } from './components/add-item-price/add-item-price.component';
import { AddItemComponent } from './components/add-item/add-item.component';
import { ItemsComponent } from './components/items/items.component';
import { ItemDetailsComponent } from './components/item-details/item-details.component';
import { ShoppingListsComponent } from './components/shopping-lists/shopping-lists.component';
import { ShoppingListDetailsComponent } from './components/shopping-list-details/shopping-list-details.component';
import { ShopDetailsComponent } from './components/shop-details/shop-details.component';


const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'register-shop', component: RegisterShopComponent},
  {path: 'home', component: HomeComponent},
  {path: 'scan-barcode', component: ScanBarcodeComponent},
  {path: 'add-shop', component: AddShopComponent},
  {path: 'add-item', component: AddItemComponent},
  {path: 'add-item-price/:id', component: AddItemPriceComponent},
  {path: 'shops', component: ShopsComponent},
  {path: 'shopping-lists', component: ShoppingListsComponent},
  {path: 'items', component: ItemsComponent},
  {path: 'items/:id/:shopId', component: ItemDetailsComponent},
  {path: 'items/:id', component: ItemDetailsComponent},
  {path: 'shops/:id', component: ShopDetailsComponent},
  {path: 'shopping-lists/:id', component: ShoppingListDetailsComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
