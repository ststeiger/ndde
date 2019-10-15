using System;
using System.Collections.Generic;
using System.Text;

namespace System.Windows.Forms
{


    public interface IMessageFilter
    {
        bool PreFilterMessage(ref Message m);
    }

}
