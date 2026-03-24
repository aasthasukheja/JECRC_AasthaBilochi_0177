import { Component } from '@angular/core';
import { Orderparent } from './order-parent/order-parent';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Orderparent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}