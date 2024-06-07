using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BankApi.Data;
using BankApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BankAccountsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BankAccountsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("AccountHolder/{accountHolderId}")]
    public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccountsByHolder(int accountHolderId)
    {
        return await _context.BankAccounts
            .Where(a => a.AccountHolderId == accountHolderId)
            .ToListAsync();
    }

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
