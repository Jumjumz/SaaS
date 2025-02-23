using Group = FastEndpoints.Group;

namespace SaaSDashboard.Endpoints.Users;

public class UserEndpoints : Group
{
    public UserEndpoints()
    {
        Configure("users", ep =>
        {
            ep.Description(x => x.Produces(200)
                .Produces(401)
                .Produces(404)
                .Produces(500)
                .WithTags("User Endpoints"));
        });
    }
}