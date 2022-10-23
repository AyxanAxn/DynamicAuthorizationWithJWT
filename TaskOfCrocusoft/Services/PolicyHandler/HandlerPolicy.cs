//using Microsoft.AspNetCore.Authorization;

//namespace TaskOfCrocusoft.Services.PolicyHandler
//{
//    public class HandlerPolicy : AuthorizationHandler<PolicyRequirements>
//    {
//        protected override Task HandleRequirementAsync
//            (AuthorizationHandlerContext context, PolicyRequirements requirement)
//        {
//            if (!context.User.HasClaim(claim => claim.Type == "title"))
//                return Task.CompletedTask;

//            if (!int.TryParse(context.User.FindFirst(c => c.Type == "title").Value, out int actualTitle))
//            {
//                return Task.CompletedTask;
//            }
//            if (actualTitle==requirement.Title)
//            {

//            }
//        }
//    }
//}
