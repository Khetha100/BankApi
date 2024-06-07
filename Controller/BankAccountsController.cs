using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BankApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller for managing bank accounts.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BankAccountsController : ControllerBase
{
    private readonly BankContext _context;

    /// <summary>
    /// Initializes a new instance of the BankAccountsController class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public BankAccountsController(BankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves bank accounts for a specific account holder.
    /// </summary>
    /// <param name="accountHolderId">The ID of the account holder.</param>
    /// <returns>A list of bank accounts associated with the account holder.</returns>
    [HttpGet("AccountHolder/{accountHolderId}")]
    public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccountsByHolder(int accountHolderId)
    {
        return await _context.BankAccounts
            .Where(a => a.AccountHolderId == accountHolderId)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a bank account by its account number.
    /// </summary>
    /// <param name="accountNumber">The account number of the bank account.</param>
    /// <returns>The bank account with the specified account number.</returns>
    [HttpGet("{accountNumber}")]
    public async Task<ActionResult<BankAccount>> GetBankAccount(string accountNumber)
    {
        var account = await _context.BankAccounts
            .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);

        if (account == null)
        {
            return NotFound();
        }

        return account;
    }

    /// <summary>
    /// Processes a withdrawal from a bank account.
    /// </summary>
    /// <param name="withdrawal">The withdrawal details.</param>
    /// <returns>The result of the withdrawal operation.</returns>
    [HttpPost("Withdraw")]
    public async Task<ActionResult> Withdraw([FromBody] Withdrawal withdrawal)
    {
        var account = await _context.BankAccounts
            .FirstOrDefaultAsync(a => a.Id == withdrawal.BankAccountId);

        if (account == null)
        {
            return NotFound("Bank account not found");
        }

        if (withdrawal.Amount <= 0)
        {
            return BadRequest("Withdrawal amount must be greater than 0");
        }

        if (withdrawal.Amount > account.AvailableBalance)
        {
            return BadRequest("Withdrawal amount exceeds available balance");
        }

        if (account.AccountType == "Fixed Deposit" && withdrawal.Amount != account.AvailableBalance)
        {
            return BadRequest("Only 100% withdrawals are allowed on Fixed Deposit accounts");
        }

        if (account.Status != "Active")
        {
            return BadRequest("Withdrawals are not allowed on inactive accounts");
        }

        account.AvailableBalance -= withdrawal.Amount;
        withdrawal.Date = DateTime.Now;

        _context.Withdrawals.Add(withdrawal);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
