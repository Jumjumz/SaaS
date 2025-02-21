using Group = FastEndpoints.Group;

namespace SaaSDashboard.Endpoints.Users;

public class UserEndpoints : Group
{
    public UserEndpoints()
    {
        Configure("users", ep =>
        {
            ep.Description(x => x.Produces(401).WithTags("User Endpoints"));
        });
    }
}