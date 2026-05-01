import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Transaction } from './transaction';
import { TransactionService } from './transaction.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  transactions: Transaction[] = [];
  displayedTransactions: Transaction[] = [];
  selectedDate: string = '';

  constructor(private transactionService: TransactionService) {}

  ngOnInit(): void {
    this.loadTransactions();
  }

  loadTransactions() {
    this.transactionService.getTransactions().subscribe({
      next: (data) => {
        console.log('API Data:', data);
        this.transactions = data;
        this.displayedTransactions = [...this.transactions];
      },
      error: (err) => {
        console.error('API Error:', err);
      }
    });
  }

  filterTransactions() {
    if (!this.selectedDate) {
      this.displayedTransactions = [...this.transactions];
      return;
    }

    this.displayedTransactions = this.transactions.filter(
      transaction => transaction.date === this.selectedDate
    );
  }

  sortByAmount() {
    this.displayedTransactions = [...this.displayedTransactions].sort(
      (a, b) => a.amount - b.amount
    );
  }
}