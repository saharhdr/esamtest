using System.Web.Mvc;

namespace Component
{
	public static class ControllerExtensions
	{

      
        public static void ShowMessage(this Controller controller, DBMessageType messageType, string message, bool showAfterRedirect = false)
		{
            var messageTypeKey = string.Empty;
            switch (messageType)
            {
                case DBMessageType.Sucsess:
                    messageTypeKey = MessageType.Success.ToString();
                    break;
                case DBMessageType.Info:
                    messageTypeKey = MessageType.Success.ToString();
                    break;
                case DBMessageType.Warning:
                    messageTypeKey = MessageType.Warning.ToString();
                    break;
                case DBMessageType.Error:
                    messageTypeKey = MessageType.Error.ToString();
                    break;
                case DBMessageType.NoShow:
                    break;
                default:
                    break;
            }
            
			if (showAfterRedirect)
			{
				controller.TempData[messageTypeKey] = message;
			}
			else
			{
				controller.ViewData[messageTypeKey] = message;
			}
		}
        public static void ShowMessage(this Controller controlle,DBmessage message,bool showAfterRedirect = false)
        {
            ShowMessage(controlle, message.Type, message.Message, showAfterRedirect);
        }
	}
}