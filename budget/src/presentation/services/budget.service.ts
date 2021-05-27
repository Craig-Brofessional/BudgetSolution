import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { share } from 'rxjs/operators';

import { IBudgetService } from './i-budget.service';
import { ExpenseDTO } from '@presentation/DTO/expense-dto';

@Injectable({
  providedIn: 'root'
})
export class BudgetService implements IBudgetService {
  private static readonly BUDGET_CONTROLLER : string = '/api/budget'; //'http://localhost:44342/api/companies'

  constructor(private http: HttpClient) {

   }

  GetExpenses(): Observable<ExpenseDTO[]> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json');
      // .set('Authorization', 'my-auth-token');
    console.log('Attempting request get: ' + BudgetService.BUDGET_CONTROLLER);

    let retVal : Observable<ExpenseDTO[]> =
      this.http.get<ExpenseDTO[]>(BudgetService.BUDGET_CONTROLLER, {headers}).pipe(share());
    retVal.subscribe(
      data => {
        console.log("GET call successful", data);
      },
      response => {
        console.log("GET call in error", response);
      },
    );

    return retVal;
  }

  GetExpense(expenseID: number): Observable<any> {
    return null;
  }

  AddExpense(expense: ExpenseDTO): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json');
      // .set('Authorization', 'my-auth-token');
    console.log('Attempting request post: ' + BudgetService.BUDGET_CONTROLLER);

    let retVal : Observable<Object> = this.http.post(BudgetService.BUDGET_CONTROLLER,
      JSON.stringify(expense),
      {headers}).pipe(share());
    retVal.subscribe(
      val => {
        console.log("POST call successful", val);
      },
      response => {
        console.log("POST call in error", response);
      },
    );

    return retVal;
  }
}
