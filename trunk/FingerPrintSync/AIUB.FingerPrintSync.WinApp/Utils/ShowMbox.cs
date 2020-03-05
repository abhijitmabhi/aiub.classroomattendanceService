using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


    public abstract class ShowMbox
    {
        ShowMbox()
        { }
        #region Error Stop Hand //x
        public static DialogResult Error( string message, string caption)
        {
            return MessageBox.Show( message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message, "Application Error Occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Error(IWin32Window owner, string message, string caption)
        {
            return MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Error(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message, "Some Error Occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Stop( string message, string caption)
        {
            return MessageBox.Show( message, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static DialogResult Stop(string message)
        {
            return MessageBox.Show(message, "Command can't be performed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static DialogResult Stop(IWin32Window owner, string message, string caption)
        {
            return MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static DialogResult Stop(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message, "Command can't be performed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        #endregion

        #region Asterisk Information //i
        public static DialogResult Information(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Information(string message)
        {
            return MessageBox.Show(message, "Application Information..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Information(IWin32Window owner, string message, string caption)
        {
            return MessageBox.Show(owner,message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Information(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message, "Important Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static DialogResult Success(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Success(string message)
        {
            return MessageBox.Show(message, "Operation Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Success(IWin32Window owner, string message, string caption)
        {
            return MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Success(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message, "Operation Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Question //?
        public static DialogResult QuestionYesNo(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult QuestionYesNo(string message)
        {
            return MessageBox.Show(message, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult QuestionYesNo(IWin32Window owner, string message, string caption)
        {
            return MessageBox.Show(owner, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult QuestionYesNo(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        #region Alert Warning Exclamation //!
        public static DialogResult AlertYesNo(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static DialogResult AlertYesNo(string message)
        {
            return MessageBox.Show(message,"Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static DialogResult AlertYesNo(IWin32Window owner,string message, string caption)
        {
            return MessageBox.Show(owner, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static DialogResult AlertYesNo(IWin32Window owner,string message)
        {
            return MessageBox.Show(owner, message, "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult Alert(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Alert(string message)
        {
            return MessageBox.Show(message, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Alert(IWin32Window owner, string message, string caption)
        {
            return MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Alert(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        #endregion






        //MessageBox.Show("Question", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//?

        //MessageBox.Show("Asterisk","", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);//i
        //MessageBox.Show("Information", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);//i

        //MessageBox.Show("Exclamation", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//!
        //MessageBox.Show("Warning", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);//!

        //MessageBox.Show("Hand", "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);//x
        //MessageBox.Show("Error", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error);//x
        //MessageBox.Show("Stop", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);//x
    }

