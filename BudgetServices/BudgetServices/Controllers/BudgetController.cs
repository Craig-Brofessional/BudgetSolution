using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace BudgetServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        BL.IExpenseService expenseService;
        public BudgetController(BL.IExpenseService _expenseService)
        {
            this.expenseService = _expenseService;
        }

        // GET api/budget
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseDTO>> Get()
        {
            try {
                Newtonsoft.Json
                List<ExpenseDTO> expenseList = this.expenseService.GetExpenses();
                return Ok(expenseList.ToArray());
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
        }

        // GET api/budget/5
        [HttpGet("{id}")]
        public ActionResult<ExpenseDTO> Get(string id)
        {
            ExpenseDTO expense = new ExpenseDTO(id);
            if (1 == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(expense);
            }
        }

        // POST api/budget
        [HttpPost]
        public void Post([FromBody] ExpenseDTO expense)
        {
            try {
                expenseService.AddExpense(expense);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                //return BadRequest(ex.ToString());
            } 
        }

        // PUT api/budget/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/budget/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
