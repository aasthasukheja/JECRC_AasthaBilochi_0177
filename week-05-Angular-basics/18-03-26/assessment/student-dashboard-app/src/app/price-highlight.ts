import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appPriceHighlight]',
  standalone: true
})
export class PriceHighlight implements OnInit {

  @Input() appPriceHighlight: number = 0;

  constructor(private el: ElementRef) {}

  ngOnInit(): void {
    if (this.appPriceHighlight > 50000) {
      this.el.nativeElement.style.color = 'red';
    } else {
      this.el.nativeElement.style.color = 'green';
    }
  }
}