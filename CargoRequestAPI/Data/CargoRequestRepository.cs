using CargoRequestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoRequestAPI.Data;

public class CargoRequestRepository : ICargoRequestRepository
{
    private readonly DataContext _context;

    public CargoRequestRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<CargoRequest>> GetCargoRequests() 
    {
        return await _context.CargoRequests
            .Include(a => a.Sender)
            .Include(a => a.Recipient)
            .Include(a => a.Cargo)
            .Include(a => a.Status)
            .ToListAsync();
    }
    
    public async Task<CargoRequest> GetById(int id) {
        return await _context.CargoRequests
            .Include(a => a.Sender)
            .Include(a => a.Recipient)
            .Include(a => a.Cargo)
            .Include(a => a.Status)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task Create(CargoRequest cargoRequest) {
        cargoRequest.Date = DateTime.Now;
        _context.CargoRequests.Add(cargoRequest);
        await _context.SaveChangesAsync();
    }
    
    public async Task Update(CargoRequest cargoRequest) {
        cargoRequest.Date = DateTime.Now;
        _context.CargoRequests.Update(cargoRequest);
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id) {
        var request = await GetById(id);
        
        var cargoToRemove = _context.Cargos.FirstOrDefault(c => c.Id == request.Cargo.Id);
        _context.Cargos.Remove(cargoToRemove);
        
        var recipientToRemove = _context.Recipients.FirstOrDefault(r => r.Id == request.Recipient.Id);
        _context.Recipients.Remove(recipientToRemove);
        
        var senderToRemove = _context.Senders.FirstOrDefault(s => s.Id == request.Sender.Id);
        _context.Senders.Remove(senderToRemove);
        
        var statusToRemove = _context.Statuses.FirstOrDefault(s => s.Id == request.Status.Id);
        _context.Statuses.Remove(statusToRemove);
        
        _context.CargoRequests.Remove(request);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CargoRequest>> SearchAll(string searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            return await _context.CargoRequests
                .Where(s => 
                    s.ReqNumber.ToString().Contains(searchString) 
                    || s.Date.ToString().Contains(searchString)
                    || s.Sender.Name.ToLower().Contains(searchString)
                    || s.Sender.Address.ToLower().Contains(searchString)
                    || s.Recipient.Name.ToLower().Contains(searchString)
                    || s.Recipient.Address.ToLower().Contains(searchString)
                )
                .Include(a => a.Sender)
                .Include(a => a.Recipient)
                .Include(a => a.Cargo)
                .Include(a => a.Status)
                .ToListAsync();
        }

        // ToDO Обработать
        return null;
    }
        
}