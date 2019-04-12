// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LocalNotifications_iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnSendAlert { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAlertStatus { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swtAlertsAllowed { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNotificationBody { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNotificationSubTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNotificationTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BtnSendAlert != null) {
                BtnSendAlert.Dispose ();
                BtnSendAlert = null;
            }

            if (lblAlertStatus != null) {
                lblAlertStatus.Dispose ();
                lblAlertStatus = null;
            }

            if (swtAlertsAllowed != null) {
                swtAlertsAllowed.Dispose ();
                swtAlertsAllowed = null;
            }

            if (txtNotificationBody != null) {
                txtNotificationBody.Dispose ();
                txtNotificationBody = null;
            }

            if (txtNotificationSubTitle != null) {
                txtNotificationSubTitle.Dispose ();
                txtNotificationSubTitle = null;
            }

            if (txtNotificationTitle != null) {
                txtNotificationTitle.Dispose ();
                txtNotificationTitle = null;
            }
        }
    }
}