import { Component } from '@angular/core';

@Component({
  selector: 'app-profile',
  standalone: true,
  templateUrl: './profile.html',
  styleUrl: './profile.css'
})
export class Profile {
  student = {
    name: 'Aastha',
    email: 'aastha@example.com',
    enrolledCourse: 'Angular Basics'
  };
}