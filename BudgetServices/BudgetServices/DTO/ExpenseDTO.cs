using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetServices.DTO
{
    public class ExpenseDTO
    {
        public string ExpenseID = null;
        public DateTime ExpenseDate = new DateTime(1900, 1, 1);
        public string ExpenseName = "";
        public string ExpenseType = "";

        public ExpenseDTO(string expenseID, DateTime? expenseDate = null, string expenseName = null, string expenseType = null)
        {
            this.ExpenseID = expenseID;

            if (expenseDate != null) 
                this.ExpenseDate = (DateTime)expenseDate;

            if (expenseName != null)
                this.ExpenseName = expenseName;

            if (expenseType != null)
                this.ExpenseType = expenseType;
        }
    }
}
