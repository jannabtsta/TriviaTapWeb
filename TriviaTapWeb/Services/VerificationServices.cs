using TriviaTapWeb;

public class VerificationServices
{
    private readonly UserData _userData;

    public VerificationServices(TriviaDBContext context)
    {
        _userData = new UserData(context);
    }

    public bool CheckIfUserNameExists(string username)
    {
        return _userData.GetUser(username) != null;
    }
}
