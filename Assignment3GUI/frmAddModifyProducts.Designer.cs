namespace Assignment3GUI
{
    partial class frmAddModifyProducts
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtVersion = new TextBox();
            btnAccept = new Button();
            btnCancel = new Button();
            label4 = new Label();
            txtProductCode = new TextBox();
            dtpReleaseDate = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 21);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 79);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 1;
            label2.Text = "Version:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 117);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 21);
            label3.TabIndex = 2;
            label3.Text = "Release Date:";
            // 
            // txtName
            // 
            txtName.Location = new Point(127, 41);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(244, 29);
            txtName.TabIndex = 1;
            txtName.Tag = "Name";
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(127, 76);
            txtVersion.MaxLength = 18;
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(88, 29);
            txtVersion.TabIndex = 2;
            txtVersion.Tag = "Version";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(87, 160);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 38);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "&Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(231, 160);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 38);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 9);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 8;
            label4.Text = "Product Code:";
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(127, 6);
            txtProductCode.MaxLength = 10;
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(88, 29);
            txtProductCode.TabIndex = 0;
            txtProductCode.Tag = "Product Code";
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.Location = new Point(127, 111);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.Size = new Size(200, 29);
            dtpReleaseDate.TabIndex = 3;
            dtpReleaseDate.Tag = "Release Date";
            // 
            // frmAddModifyProducts
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(391, 211);
            Controls.Add(dtpReleaseDate);
            Controls.Add(txtProductCode);
            Controls.Add(label4);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(txtVersion);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmAddModifyProducts";
            Text = "AddModifyProducts";
            Load += frmAddModifyProducts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtVersion;
        private Button btnAccept;
        private Button btnCancel;
        private Label label4;
        private TextBox txtProductCode;
        private DateTimePicker dtpReleaseDate;
    }
}