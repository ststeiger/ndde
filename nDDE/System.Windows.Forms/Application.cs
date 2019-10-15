
using System.Collections;
using System.Threading;

namespace System.Windows.Forms
{

    class ApplicationContext
        :Form
    {

        public ApplicationContext(Form form)
        { }

        public ApplicationContext()
        { }
    }

    public sealed class Application
    {

        public static void Run()
        {
            Run(new ApplicationContext());
        }

        public static void Run(Form mainForm)
        {
            Run(new ApplicationContext(mainForm));
        }


        public static event ThreadExceptionEventHandler ThreadException;

        private static readonly ArrayList message_filters = new ArrayList();

        public static void AddMessageFilter(IMessageFilter value)
        {
            lock (message_filters)
            {
                message_filters.Add(value);
            }
        }

    }
}