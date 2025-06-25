using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information;

public class Freelancer
{
    public Guid Id { get; set; } = Guid.NewGuid();  // Unique identifier
    public string UName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public bool IsArchived { get; set; } = false;   // Logical deletion

    public List<Skillset> Skillsets { get; set; } = new();  // One-to-many relation
    public List<Hobby> Hobbies { get; set; } = new();
}

