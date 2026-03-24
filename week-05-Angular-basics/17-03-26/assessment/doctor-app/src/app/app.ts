import { Component } from '@angular/core';
import { Appointment } from './appointment/appointment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Appointment],
  template: `<app-appointment></app-appointment>`
})
export class App {}
