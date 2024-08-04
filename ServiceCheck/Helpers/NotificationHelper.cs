using System.Windows.Forms;

namespace ServiceCheck.Helpers
{
    public class NotificationHelper
    {
        private NotifyIcon _notifyIcon;

        public NotificationHelper(NotifyIcon notifyIcon)
        {
            _notifyIcon = notifyIcon;
            _notifyIcon.Visible = false;
        }

        public void ShowBalloonTip(string title, string text, ToolTipIcon icon, int timeout = 3000)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = text;
            _notifyIcon.BalloonTipIcon = icon;
            _notifyIcon.ShowBalloonTip(timeout);
        }

        public void Show()
        {
            _notifyIcon.Visible = true;
        }

        public void Hide()
        {
            _notifyIcon.Visible = false;
        }

        public void SetContextMenu(ContextMenuStrip contextMenu)
        {
            _notifyIcon.ContextMenuStrip = contextMenu;
        }

        public void SetDoubleClickEvent(MouseEventHandler handler)
        {
            _notifyIcon.MouseDoubleClick += handler;
        }
    }
}
