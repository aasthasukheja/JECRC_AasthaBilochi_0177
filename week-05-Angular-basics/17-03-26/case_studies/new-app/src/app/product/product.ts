import { Component } from '@angular/core';

@Component({
  selector: 'app-product',
  standalone: true,
  templateUrl: './product.html',
})
export class Product {
  products = [
    {name: 'Laptop', price: 1000},
    {name: 'Phone', price: 500},
    {name: 'Tablet', price: 300},
  ];
}

