using Microsoft.AspNetCore.Mvc;
using PocketLedger;

namespace PocketLedger.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PocketController : ControllerBase
{
	private readonly Pocket_database _database;

	public PocketController(Pocket_database database)
	{
		_database = database;
	}

	[HttpGet]
	public IActionResult List_expenses()
	{
		var expenses = _database.Expenses.ToList();
		Random rand = new ();
		List<Pocket_display> formatted_expenses = new ();
		foreach (Expenses expense in expenses)
		{
			Pocket_display format = new ();
			format.Category = $"Category: {expense.category}";
			format.Name = expense.name;
			format.Formatted_amount = expense.amount.ToString("C");
			format.Formatted_date = $"At: {expense.date.ToString("MMMM dd, yyyy - hh:mm tt")}";
			format.Formatted_id = (rand.Next(10000)).ToString();
			formatted_expenses.Add(format);
		}
		return Ok(formatted_expenses);
	}

	[HttpPost]
	public IActionResult Add_expense(Expenses new_expense)
	{
		new_expense.date = DateTime.Now;
		_database.Expenses.Add(new_expense);
		_database.SaveChanges();
		return Ok();
	}
}

public class Pocket_display
{
	public string Category {get; set;}
	public string Name {get; set;}
	public string Formatted_amount {get; set;}
	public string Formatted_id {get; set;}
	public string Formatted_date {get; set;}

}