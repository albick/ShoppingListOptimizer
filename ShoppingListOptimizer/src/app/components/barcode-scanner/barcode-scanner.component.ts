import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ShopResponse } from 'src/app/models/generated';
import { ShopService } from 'src/app/services/shop.service';

@Component({
  selector: 'app-barcode-scanner',
  templateUrl: './barcode-scanner.component.html',
  styleUrls: ['./barcode-scanner.component.css']
})
export class BarcodeScannerComponent {

  res: Observable<ShopResponse[]> | undefined;
  constructor(private shopService: ShopService,private router: Router) {
  }
  ngOnInit(): void {
    this.shopService.getShops(10).subscribe(
      (response: ShopResponse[]) => {
        console.log('Shop Responses:', response);
        // Do additional processing with the response if needed
      },
      (error) => {
        console.error('Error fetching shop responses:', error);
      }
    );
  }
}
