using TriviaTapWeb.Models;
using TriviaTapWeb;

public class UserTransactionServices
{
    VerificationServices validationServices;
    UserData userData;

    public UserTransactionServices(TriviaDBContext context)
    {
        userData = new UserData(context);
        validationServices = new VerificationServices(context);
    }

    public bool CreateUser(User user)
    {
        // Check if username already exists
        if (validationServices.CheckIfUserNameExists(user.username))
        {
            return false; // Username already exists
        }

        // Create new user
        return userData.AddUser(user) > 0;
    }

    public bool CheckIfUserExists(string username, string password)
    {
        return userData.GetUser(username, password) != null;
    }

    // Check if user is admin
    public bool IsUserAdmin(string username)
    {
        var user = userData.GetUser(username);
        return user?.isAdmin ?? false;
    }
}
