import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appRole]',
  standalone: true
})
export class Role {
  @Input() appRole: string = '';

  constructor(private el: ElementRef) {}

  ngOnInit(): void {
    if (this.appRole !== 'admin') {
      this.el.nativeElement.style.display = 'none';
    }
  }
}