import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ItemQueryResponse } from 'src/app/models/generated';



@Component({
  selector: 'app-item-query-row',
  templateUrl: './item-query-row.component.html',
  styleUrls: ['./item-query-row.component.css']
})
export class ItemQueryRowComponent {
  @Input() item!: ItemQueryResponse;

  constructor(private router:Router) {
  }
  reloadPageAndRedirect(): void {
    // Navigate to the desired route
    this.router.navigate(['/items/'+this.item.itemBarcode+'/'+this.item.shopId]);

    // Reload the page after a short delay (e.g., 500 milliseconds)
    setTimeout(() => {
      window.location.reload();
    }, 200);
  }
}
