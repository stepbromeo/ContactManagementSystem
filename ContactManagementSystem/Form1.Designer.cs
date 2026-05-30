namespace ContactManagementSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            listContacts = new ListBox();
            lblStatus = new Label();
            SuspendLayout();

            // txtName
            txtName.Location = new Point(251, 48);
            txtName.Name = "txtName";
            txtName.Size = new Size(292, 23);
            txtName.TabIndex = 0;

            // txtEmail
            txtEmail.Location = new Point(251, 95);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(292, 23);
            txtEmail.TabIndex = 1;

            // txtPhone
            txtPhone.Location = new Point(251, 141);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(292, 23);
            txtPhone.TabIndex = 2;

            // label1 - Name
            label1.AutoSize = true;
            label1.Location = new Point(188, 56);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Name:";

            // label2 - Email
            label2.AutoSize = true;
            label2.Location = new Point(188, 103);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Email:";

            // label3 - Phone
            label3.AutoSize = true;
            label3.Location = new Point(188, 150);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 5;
            label3.Text = "Phone:";

            // btnAdd
            btnAdd.Location = new Point(157, 199);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnUpdate
            btnUpdate.Location = new Point(270, 199);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // btnDelete
            btnDelete.Location = new Point(392, 199);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // btnClear
            btnClear.Location = new Point(515, 199);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // listContacts
            listContacts.FormattingEnabled = true;
            listContacts.Location = new Point(157, 237);
            listContacts.Name = "listContacts";
            listContacts.Size = new Size(433, 94);
            listContacts.TabIndex = 10;
            listContacts.SelectedIndexChanged += listContacts_SelectedIndexChanged;

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(157, 340);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(listContacts);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Contact Management System";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private ListBox listContacts;
        private Label lblStatus;
    }
}