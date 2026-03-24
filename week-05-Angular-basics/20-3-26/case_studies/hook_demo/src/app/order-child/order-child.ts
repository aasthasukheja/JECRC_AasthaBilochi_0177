import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-orderchild',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './order-child.html',
  styleUrl: './order-child.css'
})
export class Orderchild {
  @Input() orderData: any;

  logs: string[] = ['created', 'checked'];
}