import { Component } from '@angular/core';

@Component({
  selector: 'app-products',
  standalone: false,
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  pageIndex!: number;
  display(pageIndex:number) {
    this.pageIndex = pageIndex;
  }
}
