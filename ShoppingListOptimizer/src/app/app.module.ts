import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {LoginComponent} from './components/login/login.component';
import {RegisterComponent} from './components/register/register.component';
import {AppRoutingModule} from "./app-routing.module";

import { NgxChartsModule } from '@swimlane/ngx-charts';

import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {RegisterShopComponent} from './components/register-shop/register-shop.component';
import {GeoapifyGeocoderAutocompleteModule} from '@geoapify/angular-geocoder-autocomplete';
import { HomeComponent } from './components/home/home.component';
import { AddShopComponent } from './components/add-shop/add-shop.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { ShopsComponent } from './components/shops/shops.component';
import { ShopRowComponent } from './components/helpers/shop-row/shop-row.component';
import { GeolocationInterceptor } from './interceptors/geolocation.interceptor';
import { ScanBarcodeComponent } from './components/scan-barcode/scan-barcode.component';
import {ZXingScannerModule} from "@zxing/ngx-scanner";
import { AddItemComponent } from './components/add-item/add-item.component';
import { AddItemPriceComponent } from './components/add-item-price/add-item-price.component';
import { ItemsComponent } from './components/items/items.component';
import { ItemQueryRowComponent } from './components/helpers/item-query-row/item-query-row.component';
import { CommonModule } from '@angular/common';
import { ShopSelectModalComponent } from './components/helpers/shop-select-modal/shop-select-modal.component';
import { ItemDetailsComponent } from './components/item-details/item-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShopDetailsComponent } from './components/shop-details/shop-details.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ShoppingListsComponent } from './components/shopping-lists/shopping-lists.component';
import { ShoppingListRowComponent } from './components/helpers/shopping-list-row/shopping-list-row.component';
import { ShoppingListDetailsComponent } from './components/shopping-list-details/shopping-list-details.component';
import { ShoppingListDeleteModalComponent } from './components/helpers/shopping-list-delete-modal/shopping-list-delete-modal.component';
import { ShoppingListNewModalComponent } from './components/helpers/shopping-list-new-modal/shopping-list-new-modal.component';
import { ShoppingListItemNewModalComponent } from './components/helpers/shopping-list-item-new-modal/shopping-list-item-new-modal.component';
import { ShoppingListAddRowComponent } from './components/helpers/shopping-list-add-row/shopping-list-add-row.component';
import { ShoppingListItemRowComponent } from './components/helpers/shopping-list-item-row/shopping-list-item-row.component';
import { ShoppingListItemDeleteModalComponent } from './components/helpers/shopping-list-item-delete-modal/shopping-list-item-delete-modal.component';
import { ShoppingListItemEditModalComponent } from './components/helpers/shopping-list-item-edit-modal/shopping-list-item-edit-modal.component';
import { OptimizerListsComponent } from './components/optimizer-lists/optimizer-lists.component';
import { OptimizerListRowComponent } from './components/helpers/optimizer-list-row/optimizer-list-row.component';
import { OptimizerSelectOptionsComponent } from './components/optimizer-select-options/optimizer-select-options.component';
import { OptimizerListItemRowComponent } from './components/helpers/optimizer-list-item-row/optimizer-list-item-row.component';
import { OptimizerResultRowComponent } from './components/helpers/optimizer-result-row/optimizer-result-row.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    RegisterShopComponent,
    HomeComponent,
    AddShopComponent,
    ShopsComponent,
    ShopRowComponent,
    ScanBarcodeComponent,
    AddItemComponent,
    AddItemPriceComponent,
    ItemsComponent,
    ItemQueryRowComponent,
    ShopSelectModalComponent,
    ItemDetailsComponent,
    ShopDetailsComponent,
    ShoppingListsComponent,
    ShoppingListRowComponent,
    ShoppingListDetailsComponent,
    ShoppingListDeleteModalComponent,
    ShoppingListNewModalComponent,
    ShoppingListItemNewModalComponent,
    ShoppingListAddRowComponent,
    ShoppingListItemRowComponent,
    ShoppingListItemDeleteModalComponent,
    ShoppingListItemEditModalComponent,
    OptimizerListsComponent,
    OptimizerListRowComponent,
    OptimizerSelectOptionsComponent,
    OptimizerListItemRowComponent,
    OptimizerResultRowComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
    NgxChartsModule,
    GeoapifyGeocoderAutocompleteModule.withConfig('d69bf89b9e5c4838bc7dd0cf2ede270a'),
    ZXingScannerModule,
    CommonModule,
    BrowserAnimationsModule,
    FontAwesomeModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: GeolocationInterceptor,
      multi: true,
    },],
  bootstrap: [AppComponent]
})
export class AppModule {
}
