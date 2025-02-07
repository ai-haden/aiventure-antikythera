namespace FormControls.Circle
{
    partial class CircleControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.SuspendLayout();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CircleControl";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CircleControl_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CircleControl_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircleControl_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CircleControl_MouseUp);
            this.SizeChanged += new System.EventHandler(this.CircleControl_SizeChanged);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
