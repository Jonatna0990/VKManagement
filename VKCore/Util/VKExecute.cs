using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace VKCore.Util
{
    public class VKExecute
    {
        public static void ExecuteOnUIThread(Action action)
        {

            var d = CoreApplication.MainView.CoreWindow.Dispatcher;

            if (d.HasThreadAccess)
            {
                action();
            }
            else
            {
                d.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        action();
                    });
            }

        }
    }
}
