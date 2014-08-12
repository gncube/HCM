using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Social.Messaging;
using DotNetNuke.Services.Social.Notifications;

namespace GND.Modules.HCM.Components
{
    public class Messaging
    {
        internal static void SendNotification(string subject, string body, UserInfo recipient)
        {
            var notificationType = NotificationsController.Instance.GetNotificationType("HtmlNotification");
            var portalSettings = PortalController.GetCurrentPortalSettings();
            //var sender = UserController.GetUserById(portalSettings.PortalId, portalSettings.AdministratorId);
            var sender = UserController.GetCurrentUserInfo();

            var notification = new Notification { NotificationTypeID = notificationType.NotificationTypeId, Subject = subject, Body = body, IncludeDismissAction = true, SenderUserID = sender.UserID };
            NotificationsController.Instance.SendNotification(notification, portalSettings.PortalId, null,
                new List<UserInfo> { recipient });


        }


        internal static void SendMessage(string subject, string body, UserInfo recipient)
        {
            var sender = UserController.GetCurrentUserInfo();
            var message = new Message
            {
                Body = body,
                From = sender.Email,
                Subject = subject,
                SenderUserID = sender.UserID,
                To = recipient.Email
            };

            MessagingController.Instance.SendMessage(message, null, new List<UserInfo> { recipient }, null, recipient);

        }

    }
}