import { Observable } from 'rxjs';

import { ExpenseDTO } from '@presentation/DTO/expense-dto';

// import { SearchData } from '@dto/DPS/search-data';
// import { SearchStatus } from '@dto/DPS/search-status';
// import { SearchResult } from '@dto/DPS/search-result';

export interface IBudgetService {
  // PerformSearch(data: SearchData): Observable<any>;
  // PerformFullSearch(data: SearchData) : Observable<[SearchStatus, SearchResult[]]>;
  GetExpenses(): Observable<ExpenseDTO[]>;
  GetExpense(expenseID: number): Observable<any>;
}
