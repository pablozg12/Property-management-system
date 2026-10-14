namespace PropertyManagement.services;

using Microsoft.EntityFrameworkCore;
using PropertyManagement.data;
using PropertyManagement.models;

public class RentService{
    private readonly ApplicationDBContext _context;

    public RentService(ApplicationDBContext context){
        _context = context;
    }

    //Obtain all rents
    public async Task<List<Rent>> getAllRentsAsync(){
        return await _context.Rents.ToListAsync();
    }

    //Obtain all rents of a user
    public async Task<List<Rent>> getAllUserRentsAsync(int clientId){
        var client = await _context.Clients.Include(c => c.rents).FirstOrDefaultAsync(u => u.IdUser == clientId);
        if (client == null || client.rents == null){
            throw new InvalidOperationException("This client doesn't have a rent.");
        }
        return client.rents.ToList();
    }

    // Buscar una renta por ID
    public async Task<Rent?> getRentByIdAsync(int id)
    {
        return await _context.Rents.FindAsync(id);
    }

    //Registrar una renta
    public async Task addRentAsync(Rent rent){

        var client = await _context.Clients.Include(c => c.rents).FirstOrDefaultAsync(u => u.IdUser == rent.IdClient);

        if (client == null){
            throw new InvalidOperationException("The client does not exist.");
        }

        bool hasActiveRents = client.rents != null && client.rents.Any(r => r.state == rentState.ACTIVE);

        if(hasActiveRents){
            throw new InvalidOperationException("This client already has an active rent.");
        }

        if(rent.amount == 0.0){
            throw new InvalidOperationException("Complete the forms to register a rent.");
        }

        _context.Rents.Add(rent);
        await _context.SaveChangesAsync();
    }

    // Eliminar una renta
    public async Task<bool> deleteRentAsync(int id)
    {
        var rent = await _context.Rents.FindAsync(id);
        if (rent == null)
        {
            return false;
        }

        if(rent.state == rentState.ACTIVE){
            return false;
        }

        _context.Rents.Remove(rent);
        await _context.SaveChangesAsync();
        return true;
    }

    //Cambiar estado de renta
    public async Task<bool> changeRentStateAsync(int id, rentState newState)
    {
        var rent = await _context.Rents.FindAsync(id);
        if (rent == null)
        {
            return false;
        }

        rent.state = newState;

        await _context.SaveChangesAsync();
        return true;
    }
}