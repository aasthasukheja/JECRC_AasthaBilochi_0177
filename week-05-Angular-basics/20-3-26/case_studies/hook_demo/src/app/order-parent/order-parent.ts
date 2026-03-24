import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Orderchild } from '../order-child/order-child';

@Component({
  selector: 'app-order-parent',
  standalone: true,
  imports: [CommonModule, Orderchild],
  templateUrl: './order-parent.html',
  styleUrl: './order-parent.css'
})
export class Orderparent {
  destroyChild = true;

  order = {
    id: 101,
    product: 'Laptop',
    amount: 50000
  };

  toggleChild() {
    this.destroyChild = !this.destroyChild;
  }
}