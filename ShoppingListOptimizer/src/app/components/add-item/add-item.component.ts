import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {ItemService} from 'src/app/services/item.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {
  id: string = "";

  form: any = {
    barcode: "",
    name: "",
    details: "",
    quantity: 0,
    unit: ""
  };
  isSuccessful: any;
  errorMessage = "";
  isAddFailed: any;
  units = ["kg", "l","piece"];

  constructor(private route: ActivatedRoute, private itemService: ItemService) {
    this.id = this.route.snapshot.paramMap.get('id') ?? "";
  }

  ngOnInit(): void {
    this.form.barcode = this.id;
  }

  onSubmit() {
    const {barcode, name, details, quantity, unit} = this.form;
    this.itemService.addItem(barcode,name,details,quantity,unit).subscribe(data=>{
      console.log(data)
      this.isAddFailed=false;
      this.isSuccessful=true;
    },error => {
      this.errorMessage=error.error;
      this.isAddFailed=true;
      console.log(error.error)
    });
  }
}
