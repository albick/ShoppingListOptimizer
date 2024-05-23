import {Component, ElementRef, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {EMPTY, Observable} from 'rxjs';
import {ShopResponse} from 'src/app/models/generated';
import {ShopService} from 'src/app/services/shop.service';
import * as L from 'leaflet';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-shop-details',
  templateUrl: './shop-details.component.html',
  styleUrls: ['./shop-details.component.css']
})
export class ShopDetailsComponent implements OnInit {
  id: string;
  shop: Observable<ShopResponse> = EMPTY;
  shopLatitude = 0;
  shopLongitude = 0;

  faMagnifyingGlass=faMagnifyingGlass;
  constructor(private route: ActivatedRoute, private shopService: ShopService, private elementRef: ElementRef) {
    this.id = this.route.snapshot.paramMap.get('id') ?? "";
  }

  ngOnInit(): void {
    this.shop = this.shopService.getShop(this.id);
    this.shop.subscribe(shop => {
      this.shopLongitude = shop.location.longitude;
      this.shopLatitude = shop.location.latitude;
    })
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      const mapElement = this.elementRef.nativeElement.querySelector('#shop_map');
      if (mapElement) {
        this.initMap(mapElement);
      } else {
        console.error('Map container not found.');
      }
    }, 500);
  }

  initMap(mapElement: HTMLElement): void {
    const isRetina = L.Browser.retina;
    const map = L.map(mapElement).setView([this.shopLatitude, this.shopLongitude], 16);
    const myAPIKey = "d69bf89b9e5c4838bc7dd0cf2ede270a";
    const baseUrl = `https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}.png?apiKey=${myAPIKey}`;
    const retinaUrl = `https://maps.geoapify.com/v1/tile/osm-bright/{z}/{x}/{y}@2x.png?apiKey=${myAPIKey}`;
    L.tileLayer(isRetina ? retinaUrl : baseUrl, {
      maxZoom: 20,
      id: 'osm-bright'
    }).addTo(map);

    const svgIconDataUri = 'data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA1NzYgNTEyIj48IS0tIUZvbnQgQXdlc29tZSBGcmVlIDYuNS4xIGJ5IEBmb250YXdlc29tZSAtIGh0dHBzOi8vZm9udGF3ZXNvbWUuY29tIExpY2Vuc2UgLSBodHRwczovL2ZvbnRhd2Vzb21lLmNvbS9saWNlbnNlL2ZyZWUgQ29weXJpZ2h0IDIwMjQgRm9udGljb25zLCBJbmMuLS0+PHBhdGggZD0iTTI1My4zIDM1LjFjNi4xLTExLjggMS41LTI2LjMtMTAuMi0zMi40cy0yNi4zLTEuNS0zMi40IDEwLjJMMTE3LjYgMTkySDMyYy0xNy43IDAtMzIgMTQuMy0zMiAzMnMxNC4zIDMyIDMyIDMyTDgzLjkgNDYzLjVDOTEgNDkyIDExNi42IDUxMiAxNDYgNTEySDQzMGMyOS40IDAgNTUtMjAgNjIuMS00OC41TDU0NCAyNTZjMTcuNyAwIDMyLTE0LjMgMzItMzJzLTE0LjMtMzItMzItMzJINDU4LjRMMzY1LjMgMTIuOUMzNTkuMiAxLjIgMzQ0LjctMy40IDMzMi45IDIuN3MtMTYuMyAyMC42LTEwLjIgMzIuNEw0MDQuMyAxOTJIMTcxLjdMMjUzLjMgMzUuMXpNMTkyIDMwNHY5NmMwIDguOC03LjIgMTYtMTYgMTZzLTE2LTcuMi0xNi0xNlYzMDRjMC04LjggNy4yLTE2IDE2LTE2czE2IDcuMiAxNiAxNnptOTYtMTZjOC44IDAgMTYgNy4yIDE2IDE2djk2YzAgOC44LTcuMiAxNi0xNiAxNnMtMTYtNy4yLTE2LTE2VjMwNGMwLTguOCA3LjItMTYgMTYtMTZ6bTEyOCAxNnY5NmMwIDguOC03LjIgMTYtMTYgMTZzLTE2LTcuMi0xNi0xNlYzMDRjMC04LjggNy4yLTE2IDE2LTE2czE2IDcuMiAxNiAxNnoiLz48L3N2Zz4=';

    let customIcon = L.divIcon({
      html: `<img src="${svgIconDataUri}" width="32" height="32">`,
      iconSize: [32, 32],
      className: "div-icon"
    });

    L.marker([this.shopLatitude, this.shopLongitude], {icon: customIcon}).addTo(map)
  }


}
