namespace Fulcrum_Data_Testing_Tool
{
    partial class Form1
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
            this.ReadData = new System.Windows.Forms.Button();
            this.txtb_FilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_LoadData = new System.Windows.Forms.Button();
            this.btn_Validate = new System.Windows.Forms.Button();
            this.label_MessageID = new System.Windows.Forms.Label();
            this.label_InferfaceName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_MessageID_Data = new System.Windows.Forms.Label();
            this.label_MessageData = new System.Windows.Forms.Label();
            this.label_InferfaceData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadData
            // 
            this.ReadData.Location = new System.Drawing.Point(958, 43);
            this.ReadData.Name = "ReadData";
            this.ReadData.Size = new System.Drawing.Size(101, 23);
            this.ReadData.TabIndex = 0;
            this.ReadData.Text = "Read XML Data";
            this.ReadData.UseVisualStyleBackColor = true;
            this.ReadData.Click += new System.EventHandler(this.ReadData_Click);
            // 
            // txtb_FilePath
            // 
            this.txtb_FilePath.Location = new System.Drawing.Point(66, 14);
            this.txtb_FilePath.Name = "txtb_FilePath";
            this.txtb_FilePath.Size = new System.Drawing.Size(671, 20);
            this.txtb_FilePath.TabIndex = 1;
            this.txtb_FilePath.Text = "C:\\VS_Workgroup\\Valid Payloads - UGL_NDB\\Inbound_ProductMaster_20170401165903_cfb" +
                "9fa086c6c452996d6eeb69fc5c22a.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "XML File";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(958, 14);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(101, 23);
            this.btn_Browse.TabIndex = 3;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1063, 379);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.Location = new System.Drawing.Point(942, 72);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(117, 23);
            this.btn_LoadData.TabIndex = 6;
            this.btn_LoadData.Text = "Load All Data in DG";
            this.btn_LoadData.UseVisualStyleBackColor = true;
            this.btn_LoadData.Click += new System.EventHandler(this.btn_LoadData_Click);
            // 
            // btn_Validate
            // 
            this.btn_Validate.Location = new System.Drawing.Point(861, 72);
            this.btn_Validate.Name = "btn_Validate";
            this.btn_Validate.Size = new System.Drawing.Size(75, 23);
            this.btn_Validate.TabIndex = 8;
            this.btn_Validate.Text = "Validate";
            this.btn_Validate.UseVisualStyleBackColor = true;
            this.btn_Validate.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_MessageID
            // 
            this.label_MessageID.AutoSize = true;
            this.label_MessageID.Location = new System.Drawing.Point(12, 72);
            this.label_MessageID.Name = "label_MessageID";
            this.label_MessageID.Size = new System.Drawing.Size(70, 13);
            this.label_MessageID.TabIndex = 9;
            this.label_MessageID.Text = "Message ID: ";
            // 
            // label_InferfaceName
            // 
            this.label_InferfaceName.AutoSize = true;
            this.label_InferfaceName.Location = new System.Drawing.Point(12, 48);
            this.label_InferfaceName.Name = "label_InferfaceName";
            this.label_InferfaceName.Size = new System.Drawing.Size(83, 13);
            this.label_InferfaceName.TabIndex = 10;
            this.label_InferfaceName.Text = "Interface Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 11;
            // 
            // label_MessageID_Data
            // 
            this.label_MessageID_Data.AutoSize = true;
            this.label_MessageID_Data.Location = new System.Drawing.Point(101, 72);
            this.label_MessageID_Data.Name = "label_MessageID_Data";
            this.label_MessageID_Data.Size = new System.Drawing.Size(0, 13);
            this.label_MessageID_Data.TabIndex = 12;
            // 
            // label_MessageData
            // 
            this.label_MessageData.AutoSize = true;
            this.label_MessageData.Location = new System.Drawing.Point(101, 72);
            this.label_MessageData.Name = "label_MessageData";
            this.label_MessageData.Size = new System.Drawing.Size(27, 13);
            this.label_MessageData.TabIndex = 13;
            this.label_MessageData.Text = "N/A";
            // 
            // label_InferfaceData
            // 
            this.label_InferfaceData.AutoSize = true;
            this.label_InferfaceData.Location = new System.Drawing.Point(101, 48);
            this.label_InferfaceData.Name = "label_InferfaceData";
            this.label_InferfaceData.Size = new System.Drawing.Size(27, 13);
            this.label_InferfaceData.TabIndex = 14;
            this.label_InferfaceData.Text = "N/A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 492);
            this.Controls.Add(this.label_InferfaceData);
            this.Controls.Add(this.label_MessageData);
            this.Controls.Add(this.label_MessageID_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_InferfaceName);
            this.Controls.Add(this.label_MessageID);
            this.Controls.Add(this.btn_Validate);
            this.Controls.Add(this.btn_LoadData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtb_FilePath);
            this.Controls.Add(this.ReadData);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadData;
        private System.Windows.Forms.TextBox txtb_FilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_LoadData;
        private System.Windows.Forms.Button btn_Validate;
        private System.Windows.Forms.Label label_MessageID;
        private System.Windows.Forms.Label label_InferfaceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_MessageID_Data;
        private System.Windows.Forms.Label label_MessageData;
        private System.Windows.Forms.Label label_InferfaceData;
    }
}

