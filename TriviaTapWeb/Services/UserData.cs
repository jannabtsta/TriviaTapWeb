using TriviaTapWeb.Models;
using Microsoft.EntityFrameworkCore;
using TriviaTapWeb;

public class UserData
{
    private readonly TriviaDBContext _context;

    public UserData(TriviaDBContext context)
    {
        _context = context;
    }

    // Add user method without hashing the password (plain text)
    public int AddUser(User user)
    {
        _context.Users.Add(user);
        return _context.SaveChanges();
    }

    // Check if user exists (for login) with plain text password comparison
    public User GetUser(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.username == username && u.password == password);
    }

    public User GetUser(string username)
    {
        return _context.Users.FirstOrDefault(u => u.username == username);
    }
}
