import { Component, Input } from '@angular/core';
import { faLocationDot } from '@fortawesome/free-solid-svg-icons';
import {ShopOptimizationItemResponse, ShopOptimizationResponse } from 'src/app/models/generated';

@Component({
  selector: 'app-optimizer-result-row',
  templateUrl: './optimizer-result-row.component.html',
  styleUrls: ['./optimizer-result-row.component.css']
})
export class OptimizerResultRowComponent {
  @Input() optimizedShop!: ShopOptimizationResponse;
  @Input() mode!: number;

  faLocationDot=faLocationDot;

  openInNewTab(){
    window.open(`https://www.google.com/maps/@${this.optimizedShop.location.latitude},${this.optimizedShop.location.longitude},17.5z`, '_blank');
  }
}
