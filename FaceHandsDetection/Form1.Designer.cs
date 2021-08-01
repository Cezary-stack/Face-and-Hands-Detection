
namespace FaceHandsDetection
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CamerasList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BrightnessTrackbar = new System.Windows.Forms.TrackBar();
            this.StopCameraButton = new System.Windows.Forms.Button();
            this.StartCameraButton = new System.Windows.Forms.Button();
            this.CameraPictureBox = new System.Windows.Forms.PictureBox();
            this.SelectPictureButton = new System.Windows.Forms.Button();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CamerasList);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.BrightnessTrackbar);
            this.splitContainer1.Panel1.Controls.Add(this.StopCameraButton);
            this.splitContainer1.Panel1.Controls.Add(this.StartCameraButton);
            this.splitContainer1.Panel1.Controls.Add(this.CameraPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FileNameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.SaveButton);
            this.splitContainer1.Panel2.Controls.Add(this.SelectPictureButton);
            this.splitContainer1.Panel2.Controls.Add(this.photoPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(971, 576);
            this.splitContainer1.SplitterDistance = 484;
            this.splitContainer1.TabIndex = 0;
            // 
            // CamerasList
            // 
            this.CamerasList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CamerasList.FormattingEnabled = true;
            this.CamerasList.Location = new System.Drawing.Point(13, 480);
            this.CamerasList.Name = "CamerasList";
            this.CamerasList.Size = new System.Drawing.Size(218, 21);
            this.CamerasList.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Brightness";
            // 
            // BrightnessTrackbar
            // 
            this.BrightnessTrackbar.Enabled = false;
            this.BrightnessTrackbar.LargeChange = 1;
            this.BrightnessTrackbar.Location = new System.Drawing.Point(12, 422);
            this.BrightnessTrackbar.Name = "BrightnessTrackbar";
            this.BrightnessTrackbar.Size = new System.Drawing.Size(450, 45);
            this.BrightnessTrackbar.TabIndex = 3;
            this.BrightnessTrackbar.Scroll += new System.EventHandler(this.BrightnessTrackbar_Scroll);
            // 
            // StopCameraButton
            // 
            this.StopCameraButton.Location = new System.Drawing.Point(368, 473);
            this.StopCameraButton.Name = "StopCameraButton";
            this.StopCameraButton.Size = new System.Drawing.Size(94, 29);
            this.StopCameraButton.TabIndex = 2;
            this.StopCameraButton.Text = "StopCamera";
            this.StopCameraButton.UseVisualStyleBackColor = true;
            this.StopCameraButton.Click += new System.EventHandler(this.StopCameraButton_Click);
            // 
            // StartCameraButton
            // 
            this.StartCameraButton.Location = new System.Drawing.Point(268, 473);
            this.StartCameraButton.Name = "StartCameraButton";
            this.StartCameraButton.Size = new System.Drawing.Size(94, 29);
            this.StartCameraButton.TabIndex = 1;
            this.StartCameraButton.Text = "StartCamera";
            this.StartCameraButton.UseVisualStyleBackColor = true;
            this.StartCameraButton.Click += new System.EventHandler(this.StartCameraButton_Click);
            // 
            // CameraPictureBox
            // 
            this.CameraPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CameraPictureBox.Location = new System.Drawing.Point(12, 12);
            this.CameraPictureBox.Name = "CameraPictureBox";
            this.CameraPictureBox.Size = new System.Drawing.Size(450, 370);
            this.CameraPictureBox.TabIndex = 0;
            this.CameraPictureBox.TabStop = false;
            // 
            // SelectPictureButton
            // 
            this.SelectPictureButton.Location = new System.Drawing.Point(13, 472);
            this.SelectPictureButton.Name = "SelectPictureButton";
            this.SelectPictureButton.Size = new System.Drawing.Size(107, 29);
            this.SelectPictureButton.TabIndex = 1;
            this.SelectPictureButton.Text = "SelectPicture";
            this.SelectPictureButton.UseVisualStyleBackColor = true;
            this.SelectPictureButton.Click += new System.EventHandler(this.SelectPictureButton_Click);
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoPictureBox.Location = new System.Drawing.Point(13, 12);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(450, 370);
            this.photoPictureBox.TabIndex = 0;
            this.photoPictureBox.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(356, 472);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(107, 29);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(13, 422);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(205, 20);
            this.FileNameTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 576);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FaceHandsDetection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox CameraPictureBox;
        private System.Windows.Forms.Button StopCameraButton;
        private System.Windows.Forms.Button StartCameraButton;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Button SelectPictureButton;
        private System.Windows.Forms.TrackBar BrightnessTrackbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CamerasList;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox FileNameTextBox;
    }
}

