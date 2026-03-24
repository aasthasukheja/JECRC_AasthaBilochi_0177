import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appStatusColor]',
  standalone: true
})
export class StatusColor implements OnInit {

  @Input() appStatusColor: number = 0;

  constructor(private el: ElementRef) {}

  ngOnInit(): void {
    if (this.appStatusColor >= 50) {
      this.el.nativeElement.style.color = 'green';
    } else {
      this.el.nativeElement.style.color = 'red';
    }
  }
}