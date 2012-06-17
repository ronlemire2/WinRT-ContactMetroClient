namespace ContactWinFormsClient {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnGetContactList = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetContact = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGetId = new System.Windows.Forms.TextBox();
            this.btnUpdateContact = new System.Windows.Forms.Button();
            this.btnDeleteContact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetContactList
            // 
            this.btnGetContactList.Location = new System.Drawing.Point(12, 12);
            this.btnGetContactList.Name = "btnGetContactList";
            this.btnGetContactList.Size = new System.Drawing.Size(86, 23);
            this.btnGetContactList.TabIndex = 0;
            this.btnGetContactList.Text = "GetContactList";
            this.btnGetContactList.UseVisualStyleBackColor = true;
            this.btnGetContactList.Click += new System.EventHandler(this.btnGetContactList_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(17, 206);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(511, 182);
            this.txtResults.TabIndex = 1;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(223, 12);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(75, 23);
            this.btnAddContact.TabIndex = 2;
            this.btnAddContact.Text = "AddContact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Results:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FirstName:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(90, 75);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(172, 20);
            this.txtFirstName.TabIndex = 5;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(90, 102);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(172, 20);
            this.txtLastName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "LastName:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(90, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(172, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Email:";
            // 
            // btnGetContact
            // 
            this.btnGetContact.Location = new System.Drawing.Point(104, 12);
            this.btnGetContact.Name = "btnGetContact";
            this.btnGetContact.Size = new System.Drawing.Size(75, 23);
            this.btnGetContact.TabIndex = 10;
            this.btnGetContact.Text = "GetContact";
            this.btnGetContact.UseVisualStyleBackColor = true;
            this.btnGetContact.Click += new System.EventHandler(this.btnGetContact_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(90, 49);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(172, 20);
            this.txtId.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Id:";
            // 
            // txtGetId
            // 
            this.txtGetId.Location = new System.Drawing.Point(181, 14);
            this.txtGetId.Name = "txtGetId";
            this.txtGetId.Size = new System.Drawing.Size(28, 20);
            this.txtGetId.TabIndex = 13;
            // 
            // btnUpdateContact
            // 
            this.btnUpdateContact.Location = new System.Drawing.Point(304, 11);
            this.btnUpdateContact.Name = "btnUpdateContact";
            this.btnUpdateContact.Size = new System.Drawing.Size(95, 23);
            this.btnUpdateContact.TabIndex = 14;
            this.btnUpdateContact.Text = "UpdateContact";
            this.btnUpdateContact.UseVisualStyleBackColor = true;
            this.btnUpdateContact.Click += new System.EventHandler(this.btnUpdateContact_Click);
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.Location = new System.Drawing.Point(405, 11);
            this.btnDeleteContact.Name = "btnDeleteContact";
            this.btnDeleteContact.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteContact.TabIndex = 15;
            this.btnDeleteContact.Text = "DeleteContact";
            this.btnDeleteContact.UseVisualStyleBackColor = true;
            this.btnDeleteContact.Click += new System.EventHandler(this.btnDeleteContact_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 400);
            this.Controls.Add(this.btnDeleteContact);
            this.Controls.Add(this.btnUpdateContact);
            this.Controls.Add(this.txtGetId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGetContact);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnGetContactList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetContactList;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetContact;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGetId;
        private System.Windows.Forms.Button btnUpdateContact;
        private System.Windows.Forms.Button btnDeleteContact;
    }
}

