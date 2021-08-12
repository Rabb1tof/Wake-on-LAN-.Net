
namespace Wake_on_LAN.Net
{
    partial class AddPcForm
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxMac = new System.Windows.Forms.TextBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_mac = new System.Windows.Forms.Label();
            this.label_note = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(101, 49);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(198, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxMac
            // 
            this.textBoxMac.Location = new System.Drawing.Point(101, 95);
            this.textBoxMac.Name = "textBoxMac";
            this.textBoxMac.Size = new System.Drawing.Size(198, 20);
            this.textBoxMac.TabIndex = 0;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(101, 144);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(198, 20);
            this.textBoxNote.TabIndex = 0;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(177, 32);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(51, 14);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "PC Name";
            // 
            // label_mac
            // 
            this.label_mac.AutoSize = true;
            this.label_mac.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mac.Location = new System.Drawing.Point(185, 78);
            this.label_mac.Name = "label_mac";
            this.label_mac.Size = new System.Drawing.Size(31, 14);
            this.label_mac.TabIndex = 1;
            this.label_mac.Text = "MAC";
            // 
            // label_note
            // 
            this.label_note.AutoSize = true;
            this.label_note.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_note.Location = new System.Drawing.Point(185, 127);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(32, 14);
            this.label_note.TabIndex = 1;
            this.label_note.Text = "Note";
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.Location = new System.Drawing.Point(145, 194);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(112, 26);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "Done";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // AddPcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(388, 232);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.label_mac);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.textBoxMac);
            this.Controls.Add(this.textBoxName);
            this.Name = "AddPcForm";
            this.ShowIcon = false;
            this.Text = "Add PC";
            this.Load += new System.EventHandler(this.AddPcForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxMac;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_mac;
        private System.Windows.Forms.Label label_note;
        private System.Windows.Forms.Button button_add;
    }
}