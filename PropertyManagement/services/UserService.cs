namespace PropertyManagement.services;

using Microsoft.EntityFrameworkCore;
using PropertyManagement.data;
using PropertyManagement.models;

public class UserService{
    private readonly ApplicationDBContext _context;

    public UserService(ApplicationDBContext context){
        _context = context;
    }

    // Obtener todos los usuarios (tanto admins como clientes)
    public async Task<List<User>> getAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    // Buscar un usuario por ID
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    // Registrar un nuevo Cliente específicamente
    public async Task<UserClient> registerClientAsync(UserClient client)
    {

        var existe = await _context.Users.AnyAsync(u => u.email == client.email);

        if (existe){
            throw new InvalidOperationException("The email is already registed.");
        }
        
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    // Registrar un nuevo Admin específicamente
    public async Task<UserAdmin> registerAdminAsync(UserAdmin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
        return admin;
    }

    // Eliminar un usuario
    public async Task<bool> deleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    // Eliminar un cliente
    public async Task<bool> deleteClientAsync(int id)
    {
        var client = await _context.Clients.Include(c => c.rents).FirstOrDefaultAsync(u => u.IdUser == id);
        if (client == null)
        {
            return false;
        }

        bool hasActiveRents = client.rents != null && client.rents.Any(r => r.state == rentState.ACTIVE);

        if (hasActiveRents){
            return false;
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }

    //Cambiar estado de cliente
    public async Task<bool> changeClientStateAsync(int id, clientState newState)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return false;
        }

        client.state = newState;

        await _context.SaveChangesAsync();
        return true;
    }
}