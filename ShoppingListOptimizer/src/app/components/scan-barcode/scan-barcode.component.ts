import { Component } from '@angular/core';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-scan-barcode',
  templateUrl: './scan-barcode.component.html',
  styleUrls: ['./scan-barcode.component.css']
})
export class ScanBarcodeComponent {
  form: any={
    barcode:""
  };
  constructor(private itemService:ItemService) {}
  onSubmit() {
    const barcode=this.form.barcode;
    this.itemService
  }
}
