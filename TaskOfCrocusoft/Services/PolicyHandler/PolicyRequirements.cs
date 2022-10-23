using Microsoft.AspNetCore.Authorization;

namespace TaskOfCrocusoft.Services.PolicyHandler
{
    public class PolicyRequirements : IAuthorizationRequirement
    {
        public PolicyRequirements(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}