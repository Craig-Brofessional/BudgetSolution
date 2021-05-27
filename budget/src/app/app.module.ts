import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExpenseGridComponent } from './expenses/expense-grid/expense-grid.component';
import { BudgetService } from '@presentation/services/budget.service';

const appRoutes: Routes = [
  // { path: '', redirectTo: '/company-maintenance', pathMatch: 'full' },
  // {path: 'company-maintenance', component: CompanyMaintenanceComponent },
  // {path: 'dps-query', component: DpsQueryComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ExpenseGridComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: false }
    )
  ],
  providers: [
    {provide: 'IBudgetService', useClass: BudgetService}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
