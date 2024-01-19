import { Component, OnInit } from '@angular/core';
import {EMPTY, Observable } from 'rxjs';
import { ItemResponse } from 'src/app/models/generated';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit{
  items: Observable<ItemResponse[]> = EMPTY;

  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Year';
  yAxisLabel: string = 'Population';
  timeline: boolean = true;




  constructor(private itemService: ItemService) {

  }
  ngOnInit(): void {
    this.items = this.itemService.getItems();
    this.items.subscribe(data=>{
      console.log(data)
    });
  }
}
