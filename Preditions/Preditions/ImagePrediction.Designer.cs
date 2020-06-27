namespace Preditions
{
    partial class ImagePrediction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagePrediction));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.predictButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textBoxDetails);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(633, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(497, 514);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Classifier details";
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.CausesValidation = false;
            this.textBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDetails.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Italic);
            this.textBoxDetails.Location = new System.Drawing.Point(4, 50);
            this.textBoxDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.ReadOnly = true;
            this.textBoxDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDetails.Size = new System.Drawing.Size(489, 460);
            this.textBoxDetails.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Load your image";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browseButton.Location = new System.Drawing.Point(228, 87);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(187, 37);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // imageBox
            // 
            this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox.BackColor = System.Drawing.Color.Black;
            this.imageBox.Location = new System.Drawing.Point(192, 219);
            this.imageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(267, 246);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 3;
            this.imageBox.TabStop = false;
            // 
            // predictButton
            // 
            this.predictButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.predictButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.predictButton.Location = new System.Drawing.Point(228, 492);
            this.predictButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.predictButton.Name = "predictButton";
            this.predictButton.Size = new System.Drawing.Size(187, 37);
            this.predictButton.TabIndex = 4;
            this.predictButton.Text = "Classify";
            this.predictButton.UseVisualStyleBackColor = true;
            this.predictButton.Click += new System.EventHandler(this.predictButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backButton.BackgroundImage")));
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(37, 36);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(61, 28);
            this.backButton.TabIndex = 11;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 57);
            this.label2.TabIndex = 12;
            this.label2.Text = "Your image ";
            // 
            // ImagePrediction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1147, 544);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.predictButton);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1162, 581);
            this.Name = "ImagePrediction";
            this.Text = "ImagePrediction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDetails;
    }
}