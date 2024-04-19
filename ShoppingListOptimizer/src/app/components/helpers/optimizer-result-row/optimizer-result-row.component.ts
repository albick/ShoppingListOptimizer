import { Component, Input } from '@angular/core';
import {ShopOptimizationItemResponse, ShopOptimizationResponse } from 'src/app/models/generated';

@Component({
  selector: 'app-optimizer-result-row',
  templateUrl: './optimizer-result-row.component.html',
  styleUrls: ['./optimizer-result-row.component.css']
})
export class OptimizerResultRowComponent {
  @Input() optimizedShop!: ShopOptimizationResponse;
  @Input() mode!: number;


}
