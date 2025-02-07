namespace Antikythera.Forms
{
    partial class CalendarTestsForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.inputDial = new FormControls.Dials.Sundial();
            this.lunarPhaseDial = new FormControls.Dials.Sundial();
            this.lunarPositionDial = new FormControls.Dials.Sundial();
            this.solarPositionDial = new FormControls.Dials.Sundial();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lunarPhaseDegreesLabel = new System.Windows.Forms.Label();
            this.lunarPositionDegreesLabel = new System.Windows.Forms.Label();
            this.solarPositionDegreesLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputDegreesLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metonicCalendarDegreesLabel = new System.Windows.Forms.Label();
            this.metonicCalendarDial = new FormControls.Dials.Sundial();
            this.sendMovementTextBox = new System.Windows.Forms.TextBox();
            this.sendMovementButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.flowIncrementTextBox = new System.Windows.Forms.TextBox();
            this.sendFlowMovementButton = new System.Windows.Forms.Button();
            this.circularTravelIndex = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rotationSpeedIndex = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(811, 461);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(56, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // inputDial
            // 
            this.inputDial.BackColor = System.Drawing.Color.Transparent;
            this.inputDial.BodyColor = System.Drawing.Color.Silver;
            this.inputDial.DialStyle = FormControls.Dials.Sundial.SundialStyle.Circular;
            this.inputDial.Location = new System.Drawing.Point(10, 38);
            this.inputDial.MaxValue = 360D;
            this.inputDial.MinValue = 0D;
            this.inputDial.Name = "inputDial";
            this.inputDial.NeedleColor = System.Drawing.Color.Tan;
            this.inputDial.Renderer = null;
            this.inputDial.ScaleColor = System.Drawing.Color.White;
            this.inputDial.ScaleDivisions = 10;
            this.inputDial.ScaleSubDivisions = 5;
            this.inputDial.Size = new System.Drawing.Size(187, 180);
            this.inputDial.TabIndex = 3;
            this.inputDial.Value = 0D;
            this.inputDial.ViewGlass = true;
            // 
            // lunarPhaseDial
            // 
            this.lunarPhaseDial.BackColor = System.Drawing.Color.Transparent;
            this.lunarPhaseDial.BodyColor = System.Drawing.Color.Silver;
            this.lunarPhaseDial.DialStyle = FormControls.Dials.Sundial.SundialStyle.Circular;
            this.lunarPhaseDial.Location = new System.Drawing.Point(440, 41);
            this.lunarPhaseDial.MaxValue = 180D;
            this.lunarPhaseDial.MinValue = 0D;
            this.lunarPhaseDial.Name = "lunarPhaseDial";
            this.lunarPhaseDial.NeedleColor = System.Drawing.Color.SteelBlue;
            this.lunarPhaseDial.Renderer = null;
            this.lunarPhaseDial.ScaleColor = System.Drawing.Color.White;
            this.lunarPhaseDial.ScaleDivisions = 2;
            this.lunarPhaseDial.ScaleSubDivisions = 1;
            this.lunarPhaseDial.Size = new System.Drawing.Size(187, 180);
            this.lunarPhaseDial.TabIndex = 4;
            this.lunarPhaseDial.Value = 0D;
            this.lunarPhaseDial.ViewGlass = true;
            // 
            // lunarPositionDial
            // 
            this.lunarPositionDial.BackColor = System.Drawing.Color.Transparent;
            this.lunarPositionDial.BodyColor = System.Drawing.Color.Gray;
            this.lunarPositionDial.DialStyle = FormControls.Dials.Sundial.SundialStyle.Circular;
            this.lunarPositionDial.Location = new System.Drawing.Point(225, 41);
            this.lunarPositionDial.MaxValue = 360D;
            this.lunarPositionDial.MinValue = 0D;
            this.lunarPositionDial.Name = "lunarPositionDial";
            this.lunarPositionDial.NeedleColor = System.Drawing.Color.White;
            this.lunarPositionDial.Renderer = null;
            this.lunarPositionDial.ScaleColor = System.Drawing.Color.White;
            this.lunarPositionDial.ScaleDivisions = 10;
            this.lunarPositionDial.ScaleSubDivisions = 5;
            this.lunarPositionDial.Size = new System.Drawing.Size(187, 180);
            this.lunarPositionDial.TabIndex = 5;
            this.lunarPositionDial.Value = 0D;
            this.lunarPositionDial.ViewGlass = true;
            // 
            // solarPositionDial
            // 
            this.solarPositionDial.BackColor = System.Drawing.Color.Transparent;
            this.solarPositionDial.BodyColor = System.Drawing.Color.Silver;
            this.solarPositionDial.DialStyle = FormControls.Dials.Sundial.SundialStyle.Circular;
            this.solarPositionDial.Location = new System.Drawing.Point(16, 41);
            this.solarPositionDial.MaxValue = 360D;
            this.solarPositionDial.MinValue = 0D;
            this.solarPositionDial.Name = "solarPositionDial";
            this.solarPositionDial.NeedleColor = System.Drawing.Color.Goldenrod;
            this.solarPositionDial.Renderer = null;
            this.solarPositionDial.ScaleColor = System.Drawing.Color.White;
            this.solarPositionDial.ScaleDivisions = 10;
            this.solarPositionDial.ScaleSubDivisions = 5;
            this.solarPositionDial.Size = new System.Drawing.Size(187, 180);
            this.solarPositionDial.TabIndex = 7;
            this.solarPositionDial.Value = 0D;
            this.solarPositionDial.ViewGlass = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Solar position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lunar position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lunar phase";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lunarPhaseDegreesLabel);
            this.groupBox1.Controls.Add(this.lunarPositionDegreesLabel);
            this.groupBox1.Controls.Add(this.solarPositionDegreesLabel);
            this.groupBox1.Controls.Add(this.solarPositionDial);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lunarPositionDial);
            this.groupBox1.Controls.Add(this.lunarPhaseDial);
            this.groupBox1.Location = new System.Drawing.Point(221, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 244);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zodiac calendar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Output degrees =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Output degrees =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Output degrees =";
            // 
            // lunarPhaseDegreesLabel
            // 
            this.lunarPhaseDegreesLabel.AutoSize = true;
            this.lunarPhaseDegreesLabel.Location = new System.Drawing.Point(532, 224);
            this.lunarPhaseDegreesLabel.Name = "lunarPhaseDegreesLabel";
            this.lunarPhaseDegreesLabel.Size = new System.Drawing.Size(16, 13);
            this.lunarPhaseDegreesLabel.TabIndex = 16;
            this.lunarPhaseDegreesLabel.Text = "...";
            // 
            // lunarPositionDegreesLabel
            // 
            this.lunarPositionDegreesLabel.AutoSize = true;
            this.lunarPositionDegreesLabel.Location = new System.Drawing.Point(317, 224);
            this.lunarPositionDegreesLabel.Name = "lunarPositionDegreesLabel";
            this.lunarPositionDegreesLabel.Size = new System.Drawing.Size(16, 13);
            this.lunarPositionDegreesLabel.TabIndex = 15;
            this.lunarPositionDegreesLabel.Text = "...";
            // 
            // solarPositionDegreesLabel
            // 
            this.solarPositionDegreesLabel.AutoSize = true;
            this.solarPositionDegreesLabel.Location = new System.Drawing.Point(108, 224);
            this.solarPositionDegreesLabel.Name = "solarPositionDegreesLabel";
            this.solarPositionDegreesLabel.Size = new System.Drawing.Size(16, 13);
            this.solarPositionDegreesLabel.TabIndex = 14;
            this.solarPositionDegreesLabel.Text = "...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.inputDegreesLabel);
            this.groupBox2.Controls.Add(this.inputDial);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 241);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input degrees";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Input degrees =";
            // 
            // inputDegreesLabel
            // 
            this.inputDegreesLabel.AutoSize = true;
            this.inputDegreesLabel.Location = new System.Drawing.Point(94, 221);
            this.inputDegreesLabel.Name = "inputDegreesLabel";
            this.inputDegreesLabel.Size = new System.Drawing.Size(16, 13);
            this.inputDegreesLabel.TabIndex = 17;
            this.inputDegreesLabel.Text = "...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.metonicCalendarDegreesLabel);
            this.groupBox3.Controls.Add(this.metonicCalendarDial);
            this.groupBox3.Location = new System.Drawing.Point(12, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(203, 235);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Metonic calendar";
            // 
            // metonicCalendarDegreesLabel
            // 
            this.metonicCalendarDegreesLabel.AutoSize = true;
            this.metonicCalendarDegreesLabel.Location = new System.Drawing.Point(79, 212);
            this.metonicCalendarDegreesLabel.Name = "metonicCalendarDegreesLabel";
            this.metonicCalendarDegreesLabel.Size = new System.Drawing.Size(16, 13);
            this.metonicCalendarDegreesLabel.TabIndex = 18;
            this.metonicCalendarDegreesLabel.Text = "...";
            // 
            // metonicCalendarDial
            // 
            this.metonicCalendarDial.BackColor = System.Drawing.Color.Transparent;
            this.metonicCalendarDial.BodyColor = System.Drawing.Color.Silver;
            this.metonicCalendarDial.DialStyle = FormControls.Dials.Sundial.SundialStyle.Circular;
            this.metonicCalendarDial.Location = new System.Drawing.Point(10, 29);
            this.metonicCalendarDial.MaxValue = 235D;
            this.metonicCalendarDial.MinValue = 0D;
            this.metonicCalendarDial.Name = "metonicCalendarDial";
            this.metonicCalendarDial.NeedleColor = System.Drawing.Color.MediumSeaGreen;
            this.metonicCalendarDial.Renderer = null;
            this.metonicCalendarDial.ScaleColor = System.Drawing.Color.White;
            this.metonicCalendarDial.ScaleDivisions = 8;
            this.metonicCalendarDial.ScaleSubDivisions = 5;
            this.metonicCalendarDial.Size = new System.Drawing.Size(187, 180);
            this.metonicCalendarDial.TabIndex = 11;
            this.metonicCalendarDial.Value = 0D;
            this.metonicCalendarDial.ViewGlass = true;
            // 
            // sendMovementTextBox
            // 
            this.sendMovementTextBox.Location = new System.Drawing.Point(79, 42);
            this.sendMovementTextBox.Name = "sendMovementTextBox";
            this.sendMovementTextBox.Size = new System.Drawing.Size(52, 20);
            this.sendMovementTextBox.TabIndex = 15;
            // 
            // sendMovementButton
            // 
            this.sendMovementButton.Location = new System.Drawing.Point(137, 42);
            this.sendMovementButton.Name = "sendMovementButton";
            this.sendMovementButton.Size = new System.Drawing.Size(40, 23);
            this.sendMovementButton.TabIndex = 14;
            this.sendMovementButton.Text = "Send";
            this.sendMovementButton.UseVisualStyleBackColor = true;
            this.sendMovementButton.Click += new System.EventHandler(this.sendMovementButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(26, 41);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(47, 23);
            this.clearButton.TabIndex = 16;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.rotationSpeedIndex);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.circularTravelIndex);
            this.groupBox4.Controls.Add(this.sendFlowMovementButton);
            this.groupBox4.Controls.Add(this.flowIncrementTextBox);
            this.groupBox4.Location = new System.Drawing.Point(410, 259);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Flow";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sendMovementButton);
            this.groupBox5.Controls.Add(this.sendMovementTextBox);
            this.groupBox5.Controls.Add(this.clearButton);
            this.groupBox5.Location = new System.Drawing.Point(616, 259);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 100);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Single";
            // 
            // flowIncrementTextBox
            // 
            this.flowIncrementTextBox.Location = new System.Drawing.Point(68, 43);
            this.flowIncrementTextBox.Name = "flowIncrementTextBox";
            this.flowIncrementTextBox.Size = new System.Drawing.Size(54, 20);
            this.flowIncrementTextBox.TabIndex = 17;
            // 
            // sendFlowMovementButton
            // 
            this.sendFlowMovementButton.Location = new System.Drawing.Point(131, 42);
            this.sendFlowMovementButton.Name = "sendFlowMovementButton";
            this.sendFlowMovementButton.Size = new System.Drawing.Size(40, 23);
            this.sendFlowMovementButton.TabIndex = 17;
            this.sendFlowMovementButton.Text = "Send";
            this.sendFlowMovementButton.UseVisualStyleBackColor = true;
            this.sendFlowMovementButton.Click += new System.EventHandler(this.sendFlowMovementButton_Click);
            // 
            // circularTravelIndex
            // 
            this.circularTravelIndex.FormattingEnabled = true;
            this.circularTravelIndex.Items.AddRange(new object[] {
            "360",
            "720",
            "1440",
            "2880"});
            this.circularTravelIndex.Location = new System.Drawing.Point(68, 20);
            this.circularTravelIndex.Name = "circularTravelIndex";
            this.circularTravelIndex.Size = new System.Drawing.Size(54, 21);
            this.circularTravelIndex.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Rotation ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Increment";
            // 
            // rotationSpeedIndex
            // 
            this.rotationSpeedIndex.FormattingEnabled = true;
            this.rotationSpeedIndex.Items.AddRange(new object[] {
            "90",
            "120",
            "150",
            "180",
            "210"});
            this.rotationSpeedIndex.Location = new System.Drawing.Point(68, 69);
            this.rotationSpeedIndex.Name = "rotationSpeedIndex";
            this.rotationSpeedIndex.Size = new System.Drawing.Size(54, 21);
            this.rotationSpeedIndex.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Speed";
            // 
            // CalendarTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 503);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closeButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(895, 541);
            this.MinimumSize = new System.Drawing.Size(895, 541);
            this.Name = "CalendarTestsForm";
            this.Text = "Calendar Tests";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private FormControls.Dials.Sundial inputDial;
        private FormControls.Dials.Sundial lunarPhaseDial;
        private FormControls.Dials.Sundial lunarPositionDial;
        private FormControls.Dials.Sundial solarPositionDial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lunarPhaseDegreesLabel;
        private System.Windows.Forms.Label lunarPositionDegreesLabel;
        private System.Windows.Forms.Label solarPositionDegreesLabel;
        private System.Windows.Forms.Label inputDegreesLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label metonicCalendarDegreesLabel;
        private FormControls.Dials.Sundial metonicCalendarDial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sendMovementTextBox;
        private System.Windows.Forms.Button sendMovementButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button sendFlowMovementButton;
        private System.Windows.Forms.TextBox flowIncrementTextBox;
        private System.Windows.Forms.ComboBox circularTravelIndex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox rotationSpeedIndex;
    }
}