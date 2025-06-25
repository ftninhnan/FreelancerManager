using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database;
public class FreelancerData
{
    public string UName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public List<string> Skillsets { get; set; } = new();
    public List<string> Hobbies { get; set; } = new();
}
