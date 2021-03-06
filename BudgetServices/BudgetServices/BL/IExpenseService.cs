using BudgetServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetServices.BL
{
    public interface IExpenseService
    {
        List<ExpenseDTO> GetExpenses();
        string AddExpense(ExpenseDTO expense);
    }
}
