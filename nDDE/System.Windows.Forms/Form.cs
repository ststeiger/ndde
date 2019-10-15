
using System;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;

namespace System.Windows.Forms
{

    public class Form : ContainerControl, System.IDisposable
    {

        // internal ControlNativeWindow window;			// object for native window handle
        //
        // Zusammenfassung:
        //     Ruft das Fensterhandle ab, an das das Steuerelement gebunden ist.
        //
        // Rückgabewerte:
        //     Ein System.IntPtr mit dem Fensterhandle (HWND) des Steuerelements.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DispId(-515)]
        public IntPtr Handle { get; }
        protected EventHandlerList Events { get; }
        static object LoadEvent = new object();

        protected virtual CreateParams CreateParams
        {
            get
            {
                const int WS_POPUP = unchecked((int)0x80000000);
                const int WS_EX_TOOLWINDOW = 0x80;

                var cp = base.CreateParams;
                cp.ExStyle = WS_EX_TOOLWINDOW;
                cp.Style = WS_POPUP;
                cp.Height = 0;
                cp.Width = 0;
                return cp;
            }
        }

        public bool Visible
        {
            get
            {
                return false;
            }
            set { }
        }


        public void Show()
        {
            this.Visible = true;
        }


        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHandleCreated
        {
            get
            {

                return true;
            }
        }


        public event EventHandler Load
        {
            add { Events.AddHandler(LoadEvent, value); }
            remove { Events.RemoveHandler(LoadEvent, value); }
        }
        public object Invoke(Delegate method)
        {
            object[] prms = null;
            if (method is EventHandler)
                prms = new object[] { this, EventArgs.Empty };

            return Invoke(method, prms);
        }
        public object Invoke(Delegate method, params object[] args)
        {
            /*
            Control control = FindControlToInvokeOn();

            if (!this.InvokeRequired)
            {
                return method.DynamicInvoke(args);
            }

            IAsyncResult result = BeginInvokeInternal(method, args, control);
            
            return EndInvoke(result);
            */
            return null;
        }


        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IAsyncResult BeginInvoke(Delegate method)
        {
            object[] prms = null;
            if (method is EventHandler)
                prms = new object[] { this, EventArgs.Empty };
            return null; // BeginInvokeInternal(method, prms);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IAsyncResult BeginInvoke(Delegate method, params object[] args)
        {
            return null; // BeginInvokeInternal(method, args);
        }
        /*
        internal IAsyncResult BeginInvokeInternal(Delegate method, object[] args)
        {
            return BeginInvokeInternal(method, args, FindControlToInvokeOn());
        }

        internal IAsyncResult BeginInvokeInternal(Delegate method, object[] args, Control control)
        {
            AsyncMethodResult result;
            AsyncMethodData data;

            result = new AsyncMethodResult();
            data = new AsyncMethodData();

            data.Handle = control.GetInvokableHandle();
            data.Method = method;
            data.Args = args;
            data.Result = result;

            if (!ExecutionContext.IsFlowSuppressed())
            {
                data.Context = ExecutionContext.Capture();
            }

            XplatUI.SendAsyncMethod(data);
            return result;
        }
        */

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public object EndInvoke(IAsyncResult asyncResult)
        {
            // AsyncMethodResult result = (AsyncMethodResult)asyncResult;
            //return result.EndInvoke();
            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}