import { Component, OnInit, Inject } from '@angular/core';
import { ExpenseDTO } from 'src/presentation/DTO/expense-dto';
import { IBudgetService } from '@presentation/services/i-budget.service';
import { BudgetService } from '@presentation/services/budget.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'expense-grid',
  templateUrl: './expense-grid.component.html',
  styleUrls: ['./expense-grid.component.less']
})
export class ExpenseGridComponent implements OnInit {
  Expenses: Map<string, ExpenseDTO>;

  constructor(@Inject('IBudgetService') private BudgetSrvc : IBudgetService) {
              // private location: Location,
              // private router: Router,
              // private route: ActivatedRoute) {
    this.Expenses = new Map<string, ExpenseDTO>();
  }

  ngOnInit() {
    this.LoadExpenses();
    
    // console.log(this.Expenses);
  }

  AddExpense() {
    // alert('Sup');
    alert(this.Expenses.get('ID1'));
    // console.log(this.Expenses['ID1']);
  }

  LoadExpenses(): void {
    this.BudgetSrvc.GetExpenses().subscribe((data : ExpenseDTO[]) => {
      this.Expenses.clear();
      for (let expense of data) {
        this.Expenses.set(expense.ExpenseID, expense);
      }
    });
    console.log('LoadCompanies()');
  }

}
