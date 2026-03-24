import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './appointment.html',
  styleUrl: './appointment.css'
})
export class Appointment {
  patientName = '';
  doctor = '';
  date = '';
  type = 'Online';
  symptoms = '';

  doctors = ['Dr. Sharma', 'Dr. Mehta', 'Dr. Gupta'];

  getFee() {
    return this.type === 'Online' ? 300 : 500;
  }

  confirm() {
    alert('Appointment Booked Successfully!');
  }
}