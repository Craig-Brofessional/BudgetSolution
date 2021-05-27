export class ExpenseDTO {
    public ExpenseID: string = null;
    public ExpenseDate: Date = new Date(1900, 1, 1);
    public ExpenseName: string = '';
    public ExpenseType: string = '';
    
    constructor(expenseID?: string, expenseDate?: Date, expenseName?: string, expenseType?: string) {
        this.ExpenseID = expenseID;
        this.ExpenseDate = expenseDate;
        this.ExpenseName = expenseName;
        this.ExpenseType = expenseType;
    }

    static Default(): ExpenseDTO {
        return new ExpenseDTO(null, new Date(1900, 1, 1), '', '');
    }
}
