namespace Antikythera.Forms
{
    partial class MotionTestsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputDial = new FormControls.Dials.Sundial();
            this.closeButton = new System.Windows.Forms.Button();
            this.inputDial = new FormControls.Dials.Sundial();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputDegreesLabel = new System.Windows.Forms.Label();
            this.outputDegreesLabel = new System.Windows.Forms.Label();
            this.sendMovementButton = new System.Windows.Forms.Button();
            this.sendMovementTextBox = new System.Windows.Forms.TextBox();
            this.planetaryGearSets = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // outputDial
            // 
            this.outputDial.BackColor = System.Drawing.Color.Transparent;
            this.outputDial.BodyColor = System.Drawing.Color.Silver;
            this.outputDial.DialStyle = FormControls.Dials.Sundial.SundialStyle.Circular;
            this.outputDial.Location = new System.Drawing.Point(212, 12);
            this.outputDial.MaxValue = 360D;
            this.outputDial.MinValue = 0D;
            this.outputDial.Name = "outputDial";
            this.outputDial.NeedleColor = System.Drawing.Color.SteelBlue;
            this.outputDial.Renderer = null;
            this.outputDial.ScaleColor = System.Drawing.Color.White;
            this.outputDial.ScaleDivisions = 10;
            this.outputDial.ScaleSubDivisions = 5;
            this.outputDial.Size = new System.Drawing.Size(187, 180);
            this.outputDial.TabIndex = 0;
            this.outputDial.Value = 0D;
            this.outputDial.ViewGlass = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(324, 226);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close form";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // inputDial
            // 
            this.inputDial.BackColor = System.Drawing.Color.Transparent;
            this.inputDial.BodyColor = System.Drawing.Color.Silver;
            this.inputDial.DialStyle = FormControls.Dials.Sundial.SundialStyle.Circular;
            this.inputDial.Location = new System.Drawing.Point(12, 12);
            this.inputDial.MaxValue = 360D;
            this.inputDial.MinValue = 0D;
            this.inputDial.Name = "inputDial";
            this.inputDial.NeedleColor = System.Drawing.Color.Goldenrod;
            this.inputDial.Renderer = null;
            this.inputDial.ScaleColor = System.Drawing.Color.White;
            this.inputDial.ScaleDivisions = 10;
            this.inputDial.ScaleSubDivisions = 5;
            this.inputDial.Size = new System.Drawing.Size(187, 180);
            this.inputDial.TabIndex = 2;
            this.inputDial.Value = 0D;
            this.inputDial.ViewGlass = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input degrees =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output degrees =";
            // 
            // inputDegreesLabel
            // 
            this.inputDegreesLabel.AutoSize = true;
            this.inputDegreesLabel.Location = new System.Drawing.Point(96, 196);
            this.inputDegreesLabel.Name = "inputDegreesLabel";
            this.inputDegreesLabel.Size = new System.Drawing.Size(0, 13);
            this.inputDegreesLabel.TabIndex = 5;
            // 
            // outputDegreesLabel
            // 
            this.outputDegreesLabel.AutoSize = true;
            this.outputDegreesLabel.Location = new System.Drawing.Point(301, 196);
            this.outputDegreesLabel.Name = "outputDegreesLabel";
            this.outputDegreesLabel.Size = new System.Drawing.Size(0, 13);
            this.outputDegreesLabel.TabIndex = 6;
            // 
            // sendMovementButton
            // 
            this.sendMovementButton.Location = new System.Drawing.Point(73, 227);
            this.sendMovementButton.Name = "sendMovementButton";
            this.sendMovementButton.Size = new System.Drawing.Size(40, 23);
            this.sendMovementButton.TabIndex = 7;
            this.sendMovementButton.Text = "Send";
            this.sendMovementButton.UseVisualStyleBackColor = true;
            this.sendMovementButton.Click += new System.EventHandler(this.SendMovementButtonClick);
            // 
            // sendMovementTextBox
            // 
            this.sendMovementTextBox.Location = new System.Drawing.Point(15, 229);
            this.sendMovementTextBox.Name = "sendMovementTextBox";
            this.sendMovementTextBox.Size = new System.Drawing.Size(52, 20);
            this.sendMovementTextBox.TabIndex = 8;
            // 
            // planetaryGearSets
            // 
            this.planetaryGearSets.FormattingEnabled = true;
            this.planetaryGearSets.Items.AddRange(new object[] {
            "Moon Gear Set",
            "Sun Gear Set",
            "Mercury Gear Set",
            "Venus Gear Set",
            "Mars Gear Set",
            "Jupiter Gear Set",
            "Saturn Gear Set"});
            this.planetaryGearSets.Location = new System.Drawing.Point(155, 227);
            this.planetaryGearSets.Name = "planetaryGearSets";
            this.planetaryGearSets.Size = new System.Drawing.Size(121, 21);
            this.planetaryGearSets.TabIndex = 9;
            // 
            // MotionTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 267);
            this.Controls.Add(this.planetaryGearSets);
            this.Controls.Add(this.sendMovementTextBox);
            this.Controls.Add(this.sendMovementButton);
            this.Controls.Add(this.outputDegreesLabel);
            this.Controls.Add(this.inputDegreesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputDial);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.outputDial);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(427, 305);
            this.MinimumSize = new System.Drawing.Size(427, 305);
            this.Name = "MotionTestsForm";
            this.Text = "Motion Tests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControls.Dials.Sundial outputDial;
        private System.Windows.Forms.Button closeButton;
        private FormControls.Dials.Sundial inputDial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label inputDegreesLabel;
        private System.Windows.Forms.Label outputDegreesLabel;
        private System.Windows.Forms.Button sendMovementButton;
        private System.Windows.Forms.TextBox sendMovementTextBox;
        private System.Windows.Forms.ComboBox planetaryGearSets;
    }
}