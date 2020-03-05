using System.Windows.Forms;

namespace AIUB.FingerPrintSync.WinApp.Utils
{
    public partial class BaseUserControl : UserControl
    {
        public BaseUserControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Checks if the control is in design mode irrespective of the depth of the control. 
        /// Doesn't work inside constructor.
        /// </summary>
        protected bool IsDesignerHosted
        {
            get
            {
                return IsControlDesignerHosted(this);
            }
        }

        protected bool IsControlDesignerHosted(System.Windows.Forms.Control ctrl)
        {
            if (ctrl != null)
            {
                if (ctrl.Site != null)
                    if (ctrl.Site.DesignMode == true)
                        return true;

                // check if parent is in design mode
                return IsControlDesignerHosted(ctrl.Parent);
            }

            return false;
        }
    }
}
