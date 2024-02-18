import {Component} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Color, NgxChartsModule} from '@swimlane/ngx-charts';
import {EMPTY, Observable } from 'rxjs';
import {ItemChartResponse} from 'src/app/models/generated';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent {
  id: string = "";


  constructor(private route: ActivatedRoute,private itemService:ItemService) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
  }

  ngOnInit():void{
    this.itemPriceAllShops=this.itemService.getChartItemPriceForShops(this.id);
    this.itemPriceAllShops.subscribe(data=>{
      console.log(data);
    })
  }

  itemPriceAllShops: Observable<ItemChartResponse[]> = EMPTY;



  view: [number, number] = [700, 300];

  // options
  legend: boolean = false;
  showLabels: boolean = true;
  animations: boolean = false;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Date';
  yAxisLabel: string = 'Price';
  timeline: boolean = true;

  colorScheme = ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5'];

  //colorScheme:Color|string='#5AA454';
}