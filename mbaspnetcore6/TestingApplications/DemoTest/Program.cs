// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Implementation im = new Implementation();
Console.WriteLine($"Add = {im.Add(1000,200)}");
Console.WriteLine($"Check Value {im.CheckValue(-9)}");
Console.WriteLine($"Login Status {im.Login("Mahesh1", "123")}");

Console.ReadLine();
public class Implementation
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public bool Login(string userName, string password)
    {
        bool isLogIn = false;
        var users = new Users();
        foreach (var user in users)
        {
            if (userName == user.UserName && password == user.Password)
            {
                isLogIn = true;
                break;
            }
        }

        return isLogIn;
    }

    public bool CheckValue(int x)
    {
        if (x < 0) return false;
        return true;
    }

    public double ProcessData(double x)
    {
        if (x <= 0)
            throw new Exception("The Parameter Cannot be 0");
        return Math.Pow(x, Convert.ToDouble(3));
    }


}

public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class Users : List<User>
{
    public Users()
    {
        Add(new User() { UserName = "Mahesh1", Password = "123" });
        Add(new User() { UserName = "Mahesh2", Password = "123" });
        Add(new User() { UserName = "Mahesh3", Password = "123" });
        Add(new User() { UserName = "Mahesh4", Password = "123" });

    }
}






