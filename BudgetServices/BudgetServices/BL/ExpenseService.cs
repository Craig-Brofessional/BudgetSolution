using BudgetServices.DL;
using BudgetServices.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetServices.BL
{
    public class ExpenseService : IExpenseService
    {
        public List<ExpenseDTO> GetExpenses()
        {
            List<ExpenseDTO> expenseList = new List<ExpenseDTO>();
            ExpenseDTO expense = new ExpenseDTO("Example");
            expenseList.Add(expense); //Temporary

            SqlHelper helper = new SqlHelper();
            helper.Query = @"
SELECT *
FROM expenses";

            using (DbConnection connection = DL.PostgreSQLProvider.GetConnection()) {
                using (IDataReader reader = DL.PostgreSQLProvider.ExecuteReader(helper, connection)) {
                    while (reader.Read()) {
                        expense = new ExpenseDTO((string)reader["ExpenseID"], (DateTime)reader["ExpenseDate"], (string)reader["ExpenseName"], (string)reader["ExpenseType"]);
                        expenseList.Add(expense);
                    }
                }
            }            

            return expenseList;
        }

        public string AddExpense(ExpenseDTO expense)
        {
            string expenseID = Guid.NewGuid().ToString();
            //ExpenseDTO expense = new ExpenseDTO("Example");
            SqlHelper helper = new SqlHelper();
            helper.Query = @"
INSERT INTO expenses
(expenseid, expensedate, expensename, expensetype)
VALUES (@ExpenseID, @ExpenseDate, @ExpenseName, @ExpenseType)";

            helper.AddParameter("@ExpenseID", expenseID, DbType.String);
            helper.AddParameter("@ExpenseDate", expense.ExpenseDate, DbType.DateTime);
            helper.AddParameter("@ExpenseName", expense.ExpenseName, DbType.String);
            helper.AddParameter("@ExpenseType", expense.ExpenseType, DbType.String);

            DL.PostgreSQLProvider.ExecuteNonQuery(helper);

            return expenseID;
        }
    }
}
