using Application.Database;
using Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IFFreelanceService
{
    Task<List<Freelancer>> GetAll();
    Task<Freelancer?> GetById(Guid id);
    Task<Freelancer> Create(FreelancerData data);
    Task Update(Guid id, FreelancerData data);
    Task Delete(Guid id);
    Task Archive(Guid id);
    Task Unarchive(Guid id);
    Task<List<Freelancer>> Search(string wildcard);
}
