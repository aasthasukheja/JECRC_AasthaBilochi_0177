import { Component, OnInit } from '@angular/core';
import { TransactionService, Transaction } from '../../services/transaction.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-record-table',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './record-table.html',
  styleUrl: './record-table.css'
})
export class RecordTableComponent implements OnInit {

  transactions: Transaction[] = [];
  selectedDate: string = '';

  // ✅ ADD THIS (missing tha)
  newTransaction: any = {
    date: '',
    description: '',
    type: 0,
    amount: 0,
    balance: ''
  };

  constructor(private service: TransactionService) {}

  ngOnInit() {
    this.loadData();
  }

  onDateChange() {
    if (!this.selectedDate) {
      this.loadData();
    }
  }

  loadData() {
    this.service.getAll().subscribe(res => {
      this.transactions = res;
    });
  }

  filter() {
    if (!this.selectedDate) {
      this.loadData();
      return;
    }

    this.service.filter(this.selectedDate).subscribe(data => {
      this.transactions = data;
    });
  }
  deleteTransaction(id: number) {
  this.service.delete(id).subscribe(() => {
    this.loadData(); // refresh
  });
}

  sort() {
    this.transactions = [...this.transactions].sort((a, b) => a.amount - b.amount);
  }

  // ✅ ADD THIS FUNCTION
addTransaction() {

  // ❌ VALIDATION CHECK
  if (
    !this.newTransaction.date ||
    !this.newTransaction.description ||
    this.newTransaction.amount <= 0 ||
    !this.newTransaction.balance
  ) {
    alert("Please fill all fields correctly!");
    return;
  }

  this.service.add(this.newTransaction).subscribe(() => {

    this.loadData();

    // reset form
    this.newTransaction = {
      date: '',
      description: '',
      type: 0,
      amount: 0,
      balance: ''
    };
  });
}
}