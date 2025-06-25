using Application.Interfaces;
using Domain.Information;
using Moq;
using Xunit;

public class FreelancerSVTests
{
    [Fact]
    public void CanCreateFreelancerEntity()
    {
        var freelancer = new Freelancer
        {
            UName = "testuser",
            Email = "test@example.com",
            PhoneNum = "0123456789",
            Skillsets = new List<Skillset> { new Skillset { Name = "C#" } },
            Hobbies = new List<Hobby> { new Hobby { Name = "Chess" } }
        };

        Assert.Equal("testuser", freelancer.UName);
        Assert.Single(freelancer.Skillsets);
        Assert.Single(freelancer.Hobbies);
    }
}
