import {Component} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Color, NgxChartsModule} from '@swimlane/ngx-charts';
import {ItemChartResponse} from 'src/app/models/generated';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent {
  id: string = "";


  constructor(private route: ActivatedRoute) {


    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

  }

  itemPriceAllShops: ItemChartResponse[] = [{
    name: "asd",
    series: [
      {
        name: "hehe1",
        value: 123
      },
      {
        name: "hehe2",
        value: 250
      }
    ]
  },
    {
      name: "asd",
      series: [
        {
          name: "hehe1",
          value: 123
        },
        {
          name: "hehe2",
          value: 250
        }
      ]
    }]

  /*itemPriceAllShops = [
     {
       "name": "Germany",
       "series": [
         {
           "name": "1990",
           "value": 62000000
         },
         {
           "name": "2010",
           "value": 73000000
         },
         {
           "name": "2011",
           "value": 89400000
         }
       ]
     },

     {
       "name": "USA",
       "series": [
         {
           "name": "1990",
           "value": 250000000
         },
         {
           "name": "2010",
           "value": 309000000
         },
         {
           "name": "2011",
           "value": 311000000
         }
       ]
     },

     {
       "name": "France",
       "series": [
         {
           "name": "1990",
           "value": 58000000
         },
         {
           "name": "2010",
           "value": 50000020
         },
         {
           "name": "2011",
           "value": 58000000
         }
       ]
     },
     {
       "name": "UK",
       "series": [
         {
           "name": "1990",
           "value": 57000000
         },
         {
           "name": "2010",
           "value": 62000000
         }
       ]
     }
   ];*/

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
