using Foundation;
using System;
using UIKit;
using UserNotifications;

namespace LocalNotifications_iOS
{
    public partial class ViewController : UIViewController
    {
        public bool alertsAllowed = false;
        public int alertCount = 1;

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
                alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            });

            BtnSendAlert.TouchUpInside += OnSendAlert;
        }

        private void OnSendAlert(object sender, EventArgs e)
        {
            //Get current notification settings
            UNUserNotificationCenter.Current.GetNotificationSettings((settings) =>
            {
                alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
                swtAlertsAllowed.On = alertsAllowed;
            });

            // Code following the suggestion made in this Xamarin Forms Forum thread
            //   https://forums.xamarin.com/discussion/comment/372220#Comment_372220

            InvokeOnMainThread(() =>
            {
                if (alertsAllowed)
                {
                    // Create the content of the Local Notification
                    UNMutableNotificationContent content = new UNMutableNotificationContent();
                    content.Title = txtNotificationTitle.Text;
                    content.Subtitle = txtNotificationSubTitle.Text;
                    content.Body = $"{txtNotificationBody.Text} with Notification Count of {alertCount}";
                    content.Badge = 1;

                    UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(15.0, false);

                    string requestID = $"SampleRequest{alertCount}";
                    UNNotificationRequest request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

                    lblAlertStatus.Text = "Sending Alert...";

                    UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
                    {
                        if (err != null)
                        {
                            //this.lblAlertStatus.Text = "Error: Alert NOT Sent";
                        }
                        else
                        {
                            //this.lblAlertStatus.Text = "Alert Sent";
                        }
                    });

                    alertCount++;
                }
                else
                    lblAlertStatus.Text = "Alerts NOT Allowed";
            });

            //if (alertsAllowed)
            //{
            //    // Create the content of the Local Notification
            //    UNMutableNotificationContent content = new UNMutableNotificationContent();
            //    content.Title = txtNotificationTitle.Text;
            //    content.Subtitle = txtNotificationSubTitle.Text;
            //    content.Body = $"{txtNotificationBody.Text} with Notification Count of {alertCount}";
            //    content.Badge = 1;

            //    UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(15.0, false);

            //    string requestID = $"SampleRequest{alertCount}";
            //    UNNotificationRequest request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            //    lblAlertStatus.Text = "Sending Alert...";

            //    UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            //    {
            //        if (err != null)
            //        {
            //            //this.lblAlertStatus.Text = "Error: Alert NOT Sent";
            //        }
            //        else
            //        {
            //            //this.lblAlertStatus.Text = "Alert Sent";
            //        }
            //    });

            //    alertCount++;
            //}
            //else
            //    lblAlertStatus.Text = "Alerts NOT Allowed";
        }

        private void OnNotificationSettings(UNNotificationSettings settings)
        {
            alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            swtAlertsAllowed.On = alertsAllowed;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}