using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Database;
using Application.Interfaces;
using Domain.Information;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class FreelancerSV : IFFreelanceService
{
    private readonly DBContext _context;

    public FreelancerSV(DBContext context)
    {
        _context = context;
    }

    public async Task<Freelancer> Create(FreelancerData data)
    {
        var freelancer = new Freelancer
        {
            UName = data.UName,
            Email = data.Email,
            PhoneNum = data.PhoneNum,
            Skillsets = data.Skillsets.Select(s => new Skillset { Name = s }).ToList(),
            Hobbies = data.Hobbies.Select(h => new Hobby { Name = h }).ToList()
        };

        _context.Freelancers.Add(freelancer);
        await _context.SaveChangesAsync();
        return freelancer;
    }

    public async Task Delete(Guid id)
    {
        var freelancer = await _context.Freelancers.FindAsync(id);
        if (freelancer is not null)
        {
            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Freelancer>> GetAll() =>
        await _context.Freelancers
            .Include(f => f.Skillsets)
            .Include(f => f.Hobbies)
            .ToListAsync();

    public async Task<Freelancer?> GetById(Guid id) =>
        await _context.Freelancers
            .Include(f => f.Skillsets)
            .Include(f => f.Hobbies)
.FirstOrDefaultAsync(f => f.Id == id);

    public async Task Update(Guid id, FreelancerData data)
    {
        var freelancer = await _context.Freelancers
            .Include(f => f.Skillsets)
            .Include(f => f.Hobbies)
    .FirstOrDefaultAsync(f => f.Id == id);

        if (freelancer == null)
            throw new Exception("Freelancer not found"); // Or return false / 404

        // Update properties
        freelancer.UName = data.UName;
        freelancer.Email = data.Email;
        freelancer.PhoneNum = data.PhoneNum;

        // Clear and update collections
        freelancer.Skillsets.Clear();
        freelancer.Skillsets.AddRange(data.Skillsets.Select(s => new Skillset { Name = s }));

        freelancer.Hobbies.Clear();
        freelancer.Hobbies.AddRange(data.Hobbies.Select(h => new Hobby { Name = h }));

        await _context.SaveChangesAsync();
    }

    public async Task Archive(Guid id)
    {
        var freelancer = await _context.Freelancers.FindAsync(id);
        if (freelancer is not null)
        {
            freelancer.IsArchived = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task Unarchive(Guid id)
    {
        var freelancer = await _context.Freelancers.FindAsync(id);
        if (freelancer is not null)
        {
            freelancer.IsArchived = false;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Freelancer>> Search(string wildcard)
    {
        return await _context.Freelancers
.Where(f => f.UName.Contains(wildcard) || f.Email.Contains(wildcard))
            .Include(f => f.Skillsets)
            .Include(f => f.Hobbies)
            .ToListAsync();
    }
}
