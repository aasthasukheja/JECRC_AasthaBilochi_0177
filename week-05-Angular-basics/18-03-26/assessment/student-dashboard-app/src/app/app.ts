import { Component } from '@angular/core';
import { StudentDashboardComponent } from './student-dashboard/student-dashboard';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [StudentDashboardComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}