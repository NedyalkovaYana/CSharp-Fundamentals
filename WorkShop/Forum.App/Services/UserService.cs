using System.Collections.Generic;
using System.Linq;
using Forum.App.Controllers;
using Forum.Data;

public static class UserService
{
    public static bool TryLogInUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return false;
        }
        ForumData forumData = new ForumData();
        bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);

        return userExists;
    }

    public static SignUpController.SignUpStatus TrySignUpUser(string username, string password)
    {
        bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
        bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

        if (!validPassword || !validUsername)
        {
            return SignUpController.SignUpStatus.DetailsError;
        }

        ForumData forumData = new ForumData();

        bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);

        if (!userAlreadyExists)
        {
            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password, new List<int>());
            forumData.Users.Add(user);
            forumData.SaveChanges();

            return SignUpController.SignUpStatus.Success;
        }

        return SignUpController.SignUpStatus.UsernameTakenError;
    }

    public static User GetUser(int id)
    {
        var forumData = new ForumData();
        var user = forumData.Users.Find(u => u.Id == id);

        return user;
    }
}

