import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from "./components/login/login.component";
import {RegisterComponent} from "./components/register/register.component";
import { RegisterShopComponent } from './components/register-shop/register-shop.component';
import { HomeComponent } from './components/home/home.component';
import { BarcodeScannerComponent } from './components/barcode-scanner/barcode-scanner.component';
import { AddShopComponent } from './components/add-shop/add-shop.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'register-shop', component: RegisterShopComponent},
  {path: 'home', component: HomeComponent},
  {path: 'scan-barcode', component: BarcodeScannerComponent},
  {path: 'add-shop', component: AddShopComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
