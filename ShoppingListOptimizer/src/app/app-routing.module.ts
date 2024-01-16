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
  {path: '', redirectTo: 'login', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
