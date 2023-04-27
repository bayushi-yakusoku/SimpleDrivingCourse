using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public static class AndroidNotificationHandler
{
    private const string CHANNEL_ID = "MyChannelId";

#if UNITY_ANDROID
    public static void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new()
        {
            Id = CHANNEL_ID,
            Name = "NotificationChannelName",
            Description = "NotificationChannelDescription",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new()
        {
            Title = "Energy recharged!",
            Text = "Your energy has recharged, come back to play!",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, CHANNEL_ID);
    }
#endif

}
