import {Component} from '@angular/core';
import {ItemService} from 'src/app/services/item.service';
import {BarcodeFormat, Result} from '@zxing/library'
import {ItemResponse} from 'src/app/models/generated';
import {EMPTY, Observable, of, switchMap} from 'rxjs';

@Component({
  selector: 'app-scan-barcode',
  templateUrl: './scan-barcode.component.html',
  styleUrls: ['./scan-barcode.component.css']
})
export class ScanBarcodeComponent {
  form: any = {
    barcode: ""
  };
  formatsEnabled: BarcodeFormat[];
  scanEnabled = true;
  itemFetched=false;


  isSuccessful: any;

  addItemShow = true;
  addPriceShow = false;

  item!: ItemResponse;

  constructor(private itemService: ItemService) {
    this.formatsEnabled = [
      BarcodeFormat.CODE_128,
      BarcodeFormat.DATA_MATRIX,
      BarcodeFormat.EAN_13,
      BarcodeFormat.QR_CODE
    ];
  }

  onSubmit() {
    const barcode = this.form.barcode;
    console.log(barcode);
    this.itemFetched=!this.itemFetched;

    this.itemService.getItemByBarcode(barcode)
      .pipe(
        switchMap(data => {
          if (data === null) {
            console.log("null");
            this.addItemShow = true;
            return EMPTY; // or any default value
          } else {
            //console.log(data)

            this.addItemShow = false;
            this.addPriceShow = true;
            return of(data); // assuming you imported 'of' from 'rxjs'
          }
        })
      )
      .subscribe(item => {
        let _item = item as ItemResponse; // Make sure to cast it to the correct type
        this.form.barcode = _item.barcode;
      });
  }

  onCodeResult(resultString: string) {
    //console.log(resultString)
    this.scanEnabled = false;
    this.form.barcode = resultString;
  }

  scanErrorHandler($event: any) {
    console.log($event)
  }

  rescan() {
    this.itemFetched=!this.itemFetched;
    this.form.barcode = "";
    this.scanEnabled = !this.scanEnabled;
    this.addItemShow = true;
    this.addPriceShow = false;
  }
}
