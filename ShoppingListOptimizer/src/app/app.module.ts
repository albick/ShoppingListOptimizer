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
    ItemsComponent
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
    ZXingScannerModule
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
