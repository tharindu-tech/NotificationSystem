using System;
public interface INotification
{
    void Send(string message);
}
public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Push Notification: {message}");
    }
}
public abstract class NotificationFactory
{
    public abstract INotification CreateNotification();

    public void NotifyUser(string message)
    {
        INotification notification = CreateNotification();
        notification.Send(message);
    }
}
public class EmailFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SMSFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SMSNotification();
    }
}

public class PushFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-Factory Method Pattern Demo-");

        NotificationFactory emailFactory = new EmailFactory();
        emailFactory.NotifyUser("Hello via Email!");

        NotificationFactory smsFactory = new SMSFactory();
        smsFactory.NotifyUser("Hello via SMS!");

        NotificationFactory pushFactory = new PushFactory();
        pushFactory.NotifyUser("Hello via Push Notification!");
    }
}
