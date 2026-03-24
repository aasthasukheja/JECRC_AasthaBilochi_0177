import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private courses = [
    {
      id: 1,
      title: 'Angular Basics',
      duration: '6 Weeks',
      instructor: 'Rahul Sharma',
      description: 'Learn components, data binding, directives, services and routing in Angular.'
    },
    {
      id: 2,
      title: 'React Fundamentals',
      duration: '5 Weeks',
      instructor: 'Anjali Mehta',
      description: 'Understand JSX, components, props, state and hooks in React.'
    },
    {
      id: 3,
      title: 'Node.js Essentials',
      duration: '4 Weeks',
      instructor: 'Vikas Gupta',
      description: 'Build backend applications using Node.js, Express and REST APIs.'
    },
    {
      id: 4,
      title: 'JavaScript Advanced',
      duration: '8 Weeks',
      instructor: 'Priya Singh',
      description: 'Deep dive into ES6, promises, async/await, DOM and advanced JS concepts.'
    }
  ];

  getCourses() {
    return this.courses;
  }

  getCourseById(id: number) {
    return this.courses.find(course => course.id === id);
  }
}