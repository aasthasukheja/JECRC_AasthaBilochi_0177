import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Role } from '../role';
import { PriceHighlight } from '../price-highlight';
import { ClickBlock } from '../click-block';
import { StatusColor } from '../status-color';
import { Theme } from '../theme';

@Component({
  selector: 'app-student-dashboard',
  standalone: true,
  imports: [CommonModule, Role, PriceHighlight, ClickBlock, StatusColor, Theme],
  templateUrl: './student-dashboard.html',
  styleUrl: './student-dashboard.css'
})
export class StudentDashboardComponent {
  students = [
    { name: 'Aastha', marks: 92 },
    { name: 'Riya', marks: 76 },
    { name: 'Karan', marks: 55 },
    { name: 'Rahul', marks: 30 }
  ];

  getGrade(marks: number): string {
    if (marks >= 85) {
      return 'A';
    } else if (marks >= 60) {
      return 'B';
    } else if (marks >= 40) {
      return 'C';
    } else {
      return 'F';
    }
  }

  currentTheme = 'light';

toggleTheme() {
  this.currentTheme = this.currentTheme === 'light' ? 'dark' : 'light';
}
}