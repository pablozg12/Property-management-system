namespace PropertyManagement.services;

using Microsoft.EntityFrameworkCore;
using PropertyManagement.data;
using PropertyManagement.models;

public class PaymentService{
    private readonly ApplicationDBContext _context;

    public PaymentService(ApplicationDBContext context){
        _context = context;
    }

    //Register a payment
    public async Task addPaymentAsync(Payment payment){
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }
}