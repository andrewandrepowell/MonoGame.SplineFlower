﻿namespace MonoGame.SplineFlower.Samples
{
    partial class SplineForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplineForm));
            this.tabControlEditorTabs = new System.Windows.Forms.TabControl();
            this.tabPageAdvancedControls = new System.Windows.Forms.TabPage();
            this.advancedControls = new MonoGame.SplineFlower.Samples.Controls.AdvancedControls();
            this.tabPageSimpleLine = new System.Windows.Forms.TabPage();
            this.lineControl = new MonoGame.SplineFlower.Samples.Controls.LineControl();
            this.tabPageQuadraticBezier = new System.Windows.Forms.TabPage();
            this.curveControlQuadratic = new MonoGame.SplineFlower.Samples.Controls.CurveControl();
            this.tabPageCubicBezier = new System.Windows.Forms.TabPage();
            this.curveControlCubic = new MonoGame.SplineFlower.Samples.Controls.CurveControl();
            this.tabPageBezierSpline = new System.Windows.Forms.TabPage();
            this.comboBoxWalkerMode = new System.Windows.Forms.ComboBox();
            this.buttonResetSplineWalker = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.buttonAddCurveRight = new System.Windows.Forms.Button();
            this.buttonAddCurveLeft = new System.Windows.Forms.Button();
            this.splineControl = new MonoGame.SplineFlower.Samples.Controls.SplineControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButtonGitHub = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonTwitter = new System.Windows.Forms.ToolStripDropDownButton();
            this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.tabControlEditorTabs.SuspendLayout();
            this.tabPageAdvancedControls.SuspendLayout();
            this.tabPageSimpleLine.SuspendLayout();
            this.tabPageQuadraticBezier.SuspendLayout();
            this.tabPageCubicBezier.SuspendLayout();
            this.tabPageBezierSpline.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEditorTabs
            // 
            this.tabControlEditorTabs.Controls.Add(this.tabPageAdvancedControls);
            this.tabControlEditorTabs.Controls.Add(this.tabPageSimpleLine);
            this.tabControlEditorTabs.Controls.Add(this.tabPageQuadraticBezier);
            this.tabControlEditorTabs.Controls.Add(this.tabPageCubicBezier);
            this.tabControlEditorTabs.Controls.Add(this.tabPageBezierSpline);
            this.tabControlEditorTabs.Controls.Add(this.tabPageInfo);
            this.tabControlEditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEditorTabs.Location = new System.Drawing.Point(0, 0);
            this.tabControlEditorTabs.Name = "tabControlEditorTabs";
            this.tabControlEditorTabs.SelectedIndex = 0;
            this.tabControlEditorTabs.Size = new System.Drawing.Size(582, 553);
            this.tabControlEditorTabs.TabIndex = 2;
            // 
            // tabPageAdvancedControls
            // 
            this.tabPageAdvancedControls.Controls.Add(this.buttonHelp);
            this.tabPageAdvancedControls.Controls.Add(this.advancedControls);
            this.tabPageAdvancedControls.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdvancedControls.Name = "tabPageAdvancedControls";
            this.tabPageAdvancedControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvancedControls.Size = new System.Drawing.Size(574, 524);
            this.tabPageAdvancedControls.TabIndex = 5;
            this.tabPageAdvancedControls.Text = "AdvancedControls";
            this.tabPageAdvancedControls.UseVisualStyleBackColor = true;
            // 
            // advancedControls
            // 
            this.advancedControls.BackColor = System.Drawing.Color.Tan;
            this.advancedControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedControls.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedControls.ForeColor = System.Drawing.Color.GhostWhite;
            this.advancedControls.GetAllPoints = null;
            this.advancedControls.Location = new System.Drawing.Point(3, 3);
            this.advancedControls.Name = "advancedControls";
            this.advancedControls.SelectedTrigger = null;
            this.advancedControls.Size = new System.Drawing.Size(568, 518);
            this.advancedControls.TabIndex = 0;
            this.advancedControls.Text = "Advanced Controls";
            this.advancedControls.TryGetTransformFromPosition = null;
            this.advancedControls.TryGetTriggerFromPosition = null;
            // 
            // tabPageSimpleLine
            // 
            this.tabPageSimpleLine.Controls.Add(this.lineControl);
            this.tabPageSimpleLine.Location = new System.Drawing.Point(4, 25);
            this.tabPageSimpleLine.Name = "tabPageSimpleLine";
            this.tabPageSimpleLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSimpleLine.Size = new System.Drawing.Size(574, 524);
            this.tabPageSimpleLine.TabIndex = 0;
            this.tabPageSimpleLine.Text = "Simple Line";
            this.tabPageSimpleLine.UseVisualStyleBackColor = true;
            // 
            // lineControl
            // 
            this.lineControl.BackColor = System.Drawing.Color.Lavender;
            this.lineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineControl.ForeColor = System.Drawing.Color.CadetBlue;
            this.lineControl.GetAllPoints = null;
            this.lineControl.Location = new System.Drawing.Point(3, 3);
            this.lineControl.MyLine = null;
            this.lineControl.Name = "lineControl";
            this.lineControl.SelectedTrigger = null;
            this.lineControl.Size = new System.Drawing.Size(568, 518);
            this.lineControl.TabIndex = 0;
            this.lineControl.Text = "Simple Line";
            this.lineControl.TryGetTransformFromPosition = null;
            this.lineControl.TryGetTriggerFromPosition = null;
            // 
            // tabPageQuadraticBezier
            // 
            this.tabPageQuadraticBezier.Controls.Add(this.curveControlQuadratic);
            this.tabPageQuadraticBezier.Location = new System.Drawing.Point(4, 25);
            this.tabPageQuadraticBezier.Name = "tabPageQuadraticBezier";
            this.tabPageQuadraticBezier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuadraticBezier.Size = new System.Drawing.Size(574, 524);
            this.tabPageQuadraticBezier.TabIndex = 1;
            this.tabPageQuadraticBezier.Text = "Quadratic Beziér Curve";
            this.tabPageQuadraticBezier.UseVisualStyleBackColor = true;
            // 
            // curveControlQuadratic
            // 
            this.curveControlQuadratic.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.curveControlQuadratic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curveControlQuadratic.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curveControlQuadratic.GetAllPoints = null;
            this.curveControlQuadratic.Location = new System.Drawing.Point(3, 3);
            this.curveControlQuadratic.Name = "curveControlQuadratic";
            this.curveControlQuadratic.SelectedTrigger = null;
            this.curveControlQuadratic.Size = new System.Drawing.Size(568, 518);
            this.curveControlQuadratic.TabIndex = 0;
            this.curveControlQuadratic.Text = "Quadratic Bézier Curve";
            this.curveControlQuadratic.TryGetTransformFromPosition = null;
            this.curveControlQuadratic.TryGetTriggerFromPosition = null;
            // 
            // tabPageCubicBezier
            // 
            this.tabPageCubicBezier.Controls.Add(this.curveControlCubic);
            this.tabPageCubicBezier.Location = new System.Drawing.Point(4, 25);
            this.tabPageCubicBezier.Name = "tabPageCubicBezier";
            this.tabPageCubicBezier.Size = new System.Drawing.Size(574, 524);
            this.tabPageCubicBezier.TabIndex = 2;
            this.tabPageCubicBezier.Text = "Cubic Beziér Curve";
            this.tabPageCubicBezier.UseVisualStyleBackColor = true;
            // 
            // curveControlCubic
            // 
            this.curveControlCubic.BackColor = System.Drawing.Color.MediumAquamarine;
            this.curveControlCubic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curveControlCubic.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curveControlCubic.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.curveControlCubic.GetAllPoints = null;
            this.curveControlCubic.GetBezierType = MonoGame.SplineFlower.Samples.Controls.CurveControl.BezierType.Cubic;
            this.curveControlCubic.Location = new System.Drawing.Point(0, 0);
            this.curveControlCubic.Name = "curveControlCubic";
            this.curveControlCubic.SelectedTrigger = null;
            this.curveControlCubic.Size = new System.Drawing.Size(574, 524);
            this.curveControlCubic.TabIndex = 0;
            this.curveControlCubic.Text = "Cubic Bézier Curve";
            this.curveControlCubic.TryGetTransformFromPosition = null;
            this.curveControlCubic.TryGetTriggerFromPosition = null;
            // 
            // tabPageBezierSpline
            // 
            this.tabPageBezierSpline.Controls.Add(this.comboBoxWalkerMode);
            this.tabPageBezierSpline.Controls.Add(this.buttonResetSplineWalker);
            this.tabPageBezierSpline.Controls.Add(this.buttonLoop);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveRight);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveLeft);
            this.tabPageBezierSpline.Controls.Add(this.splineControl);
            this.tabPageBezierSpline.Location = new System.Drawing.Point(4, 25);
            this.tabPageBezierSpline.Name = "tabPageBezierSpline";
            this.tabPageBezierSpline.Size = new System.Drawing.Size(574, 524);
            this.tabPageBezierSpline.TabIndex = 3;
            this.tabPageBezierSpline.Text = "Beziér Spline";
            this.tabPageBezierSpline.UseVisualStyleBackColor = true;
            // 
            // comboBoxWalkerMode
            // 
            this.comboBoxWalkerMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWalkerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWalkerMode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWalkerMode.FormattingEnabled = true;
            this.comboBoxWalkerMode.Items.AddRange(new object[] {
            "Once",
            "Loop",
            "PingPong"});
            this.comboBoxWalkerMode.Location = new System.Drawing.Point(391, 452);
            this.comboBoxWalkerMode.MaxDropDownItems = 3;
            this.comboBoxWalkerMode.Name = "comboBoxWalkerMode";
            this.comboBoxWalkerMode.Size = new System.Drawing.Size(107, 26);
            this.comboBoxWalkerMode.TabIndex = 5;
            this.comboBoxWalkerMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxWalkerMode_SelectedIndexChanged);
            // 
            // buttonResetSplineWalker
            // 
            this.buttonResetSplineWalker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetSplineWalker.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetSplineWalker.Location = new System.Drawing.Point(391, 484);
            this.buttonResetSplineWalker.Name = "buttonResetSplineWalker";
            this.buttonResetSplineWalker.Size = new System.Drawing.Size(180, 37);
            this.buttonResetSplineWalker.TabIndex = 4;
            this.buttonResetSplineWalker.Text = "Reset SplineWalker";
            this.buttonResetSplineWalker.UseVisualStyleBackColor = true;
            this.buttonResetSplineWalker.Click += new System.EventHandler(this.buttonResetSplineWalker_Click);
            // 
            // buttonLoop
            // 
            this.buttonLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoop.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoop.Location = new System.Drawing.Point(504, 441);
            this.buttonLoop.Name = "buttonLoop";
            this.buttonLoop.Size = new System.Drawing.Size(67, 37);
            this.buttonLoop.TabIndex = 3;
            this.buttonLoop.Text = "Loop";
            this.buttonLoop.UseVisualStyleBackColor = true;
            this.buttonLoop.Click += new System.EventHandler(this.buttonLoop_Click);
            // 
            // buttonAddCurveRight
            // 
            this.buttonAddCurveRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCurveRight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCurveRight.Location = new System.Drawing.Point(3, 484);
            this.buttonAddCurveRight.Name = "buttonAddCurveRight";
            this.buttonAddCurveRight.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveRight.TabIndex = 2;
            this.buttonAddCurveRight.Text = "Add Curve Right";
            this.buttonAddCurveRight.UseVisualStyleBackColor = true;
            this.buttonAddCurveRight.Click += new System.EventHandler(this.buttonAddCurveRight_Click);
            // 
            // buttonAddCurveLeft
            // 
            this.buttonAddCurveLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCurveLeft.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCurveLeft.Location = new System.Drawing.Point(3, 441);
            this.buttonAddCurveLeft.Name = "buttonAddCurveLeft";
            this.buttonAddCurveLeft.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveLeft.TabIndex = 1;
            this.buttonAddCurveLeft.Text = "Add Curve Left";
            this.buttonAddCurveLeft.UseVisualStyleBackColor = true;
            this.buttonAddCurveLeft.Click += new System.EventHandler(this.buttonAddCurve_Click);
            // 
            // splineControl
            // 
            this.splineControl.BackColor = System.Drawing.Color.GreenYellow;
            this.splineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineControl.ForeColor = System.Drawing.Color.DarkOrange;
            this.splineControl.GetAllPoints = null;
            this.splineControl.Location = new System.Drawing.Point(0, 0);
            this.splineControl.Name = "splineControl";
            this.splineControl.SelectedTrigger = null;
            this.splineControl.Size = new System.Drawing.Size(574, 524);
            this.splineControl.TabIndex = 12;
            this.splineControl.Text = "Bézier Spline";
            this.splineControl.TryGetTransformFromPosition = null;
            this.splineControl.TryGetTriggerFromPosition = null;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.statusStrip);
            this.tabPageInfo.Controls.Add(this.richTextBoxLicense);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(574, 524);
            this.tabPageInfo.TabIndex = 4;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonGitHub,
            this.toolStripDropDownButtonTwitter});
            this.statusStrip.Location = new System.Drawing.Point(3, 483);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(568, 38);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            // 
            // toolStripDropDownButtonGitHub
            // 
            this.toolStripDropDownButtonGitHub.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButtonGitHub.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonGitHub.Image")));
            this.toolStripDropDownButtonGitHub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonGitHub.Name = "toolStripDropDownButtonGitHub";
            this.toolStripDropDownButtonGitHub.Size = new System.Drawing.Size(335, 36);
            this.toolStripDropDownButtonGitHub.Text = "MonoGame.SplineFlower";
            this.toolStripDropDownButtonGitHub.Click += new System.EventHandler(this.toolStripDropDownButtonGitHub_Click);
            // 
            // toolStripDropDownButtonTwitter
            // 
            this.toolStripDropDownButtonTwitter.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButtonTwitter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTwitter.Image")));
            this.toolStripDropDownButtonTwitter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonTwitter.Name = "toolStripDropDownButtonTwitter";
            this.toolStripDropDownButtonTwitter.Size = new System.Drawing.Size(158, 36);
            this.toolStripDropDownButtonTwitter.Text = "#sqrMin1";
            this.toolStripDropDownButtonTwitter.Click += new System.EventHandler(this.toolStripDropDownButtonTwitter_Click);
            // 
            // richTextBoxLicense
            // 
            this.richTextBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLicense.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxLicense.Name = "richTextBoxLicense";
            this.richTextBoxLicense.Size = new System.Drawing.Size(568, 518);
            this.richTextBoxLicense.TabIndex = 2;
            this.richTextBoxLicense.Text = resources.GetString("richTextBoxLicense.Text");
            this.richTextBoxLicense.ZoomFactor = 1.5F;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.Location = new System.Drawing.Point(535, 6);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(31, 32);
            this.buttonHelp.TabIndex = 1;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // SplineForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.tabControlEditorTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonoGame.SplineFlower";
            this.Load += new System.EventHandler(this.SplineEditorForm_Load);
            this.ResizeEnd += new System.EventHandler(this.SplineEditorForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.SplineEditorForm_Resize);
            this.tabControlEditorTabs.ResumeLayout(false);
            this.tabPageAdvancedControls.ResumeLayout(false);
            this.tabPageSimpleLine.ResumeLayout(false);
            this.tabPageQuadraticBezier.ResumeLayout(false);
            this.tabPageCubicBezier.ResumeLayout(false);
            this.tabPageBezierSpline.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlEditorTabs;
        private System.Windows.Forms.TabPage tabPageSimpleLine;
        private System.Windows.Forms.TabPage tabPageQuadraticBezier;
        private System.Windows.Forms.TabPage tabPageCubicBezier;
        private System.Windows.Forms.TabPage tabPageBezierSpline;
        private System.Windows.Forms.Button buttonAddCurveLeft;
        private System.Windows.Forms.Button buttonAddCurveRight;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.Button buttonResetSplineWalker;
        private System.Windows.Forms.ComboBox comboBoxWalkerMode;
        private Controls.LineControl lineControl;
        private Controls.CurveControl curveControlQuadratic;
        private Controls.CurveControl curveControlCubic;
        private Controls.SplineControl splineControl;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.RichTextBox richTextBoxLicense;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonGitHub;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTwitter;
        private System.Windows.Forms.TabPage tabPageAdvancedControls;
        private Controls.AdvancedControls advancedControls;
        private System.Windows.Forms.Button buttonHelp;
    }
}

