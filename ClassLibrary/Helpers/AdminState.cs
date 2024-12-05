namespace ClassLibrary.Helpers;

/// <summary>
/// Holder styr på, om en admin er logget ind, og viser eller skjuler CRUD-funktioner baseret på det.
/// </summary>
public static class AdminState
{
    private static readonly string _username = "admin";
    private static readonly string _password = "1234";
    public static bool IsAdminLoggedIn { get; private set; }

    public static bool AdminLogin(string username, string password)
    {
        if (username == _username && password == _password)
        {
            IsAdminLoggedIn = true;
            return true;
        }
        return false;
    }

    public static void Logout()
    {
        IsAdminLoggedIn = false;
    }
}
