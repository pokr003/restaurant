using Microsoft.EntityFrameworkCore;
using Restaurant.API.Data;
using Restaurant.API.Entities;

namespace Restaurant.API.Repositories;

public class DeskRepository(RestaurantDbContext context) : IDeskRepository
{
    private readonly RestaurantDbContext _context = context;

    public IQueryable<Desk> SelectAllDesks() =>
        _context.Desks.AsNoTracking().AsQueryable();

    public IQueryable<Desk> SelectDeskById(Guid id) =>
        _context.Desks
            .Where(d => d.Id == id)
            .AsNoTracking()
            .AsQueryable();

    public IQueryable<Desk> SelectDeskByName(string name) =>
        _context.Desks
            .Where(d => d.Name == name)
            .AsNoTracking()
            .AsQueryable();

    public async Task<Desk?> CreateDeskAsync(string name)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var desk = new Desk { Name = name };
            await _context.Desks.AddAsync(desk);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return desk;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return null;
        }
    }

    public async Task<bool> UpdateDeskAsync(Desk desk)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            _context.Desks.Update(desk);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> RemoveDeskAsync(Desk desk)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            _context.Desks.Remove(desk);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}
