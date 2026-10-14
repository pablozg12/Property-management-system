namespace PropertyManagement.services;

using Microsoft.EntityFrameworkCore;
using PropertyManagement.data;
using PropertyManagement.models;

public class PropertyService{
    private readonly ApplicationDBContext _context;

    public PropertyService(ApplicationDBContext context){
        _context = context;
    }

    //Obtain all the properties
    public async Task<List<Property>> getAllPropertiesAsync(){
        return await _context.Properties.ToListAsync();
    }

    //Obtain a property by ID
    public async Task<Property?> getPropertyByIdAsync(int id){
        return await _context.Properties.FindAsync(id);
    }

    //Register a property
    public async Task addPropertyAsync(Property property){
        if(property.name == null || property.monthlyPayment == 0 || property.description == null){
            throw new InvalidOperationException("Complete the forms to register a property.");
        }

        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
    }

    //Delete a property
    public async Task<bool> deletePropertyAsync(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
        {
            return false;
        }

        if(property.state == propertyState.AVAILABLE){
            return false;
        }

        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
        return true;
    }

    //Change property's state
    public async Task<bool> changePropertyStateAsync(int id, propertyState newState)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
        {
            return false;
        }

        property.state = newState;

        await _context.SaveChangesAsync();
        return true;
    }
}