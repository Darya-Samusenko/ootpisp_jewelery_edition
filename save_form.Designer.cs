namespace oop_crud
{
    partial class save_form
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
            save_button = new System.Windows.Forms.Button();
            serializator_panel = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            ser_choice = new System.Windows.Forms.ComboBox();
            cipher_panel = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            cipher_choice = new System.Windows.Forms.ComboBox();
            save_dlg = new System.Windows.Forms.SaveFileDialog();
            cipher_needed = new System.Windows.Forms.RadioButton();
            serializator_panel.SuspendLayout();
            cipher_panel.SuspendLayout();
            SuspendLayout();
            // 
            // save_button
            // 
            save_button.Location = new System.Drawing.Point(138, 410);
            save_button.Name = "save_button";
            save_button.Size = new System.Drawing.Size(455, 34);
            save_button.TabIndex = 0;
            save_button.Text = "Сохранить";
            save_button.UseVisualStyleBackColor = true;
            save_button.Click += save_button_Click;
            // 
            // serializator_panel
            // 
            serializator_panel.Controls.Add(label1);
            serializator_panel.Controls.Add(ser_choice);
            serializator_panel.Location = new System.Drawing.Point(0, 0);
            serializator_panel.Name = "serializator_panel";
            serializator_panel.Size = new System.Drawing.Size(731, 150);
            serializator_panel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(138, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(263, 25);
            label1.TabIndex = 1;
            label1.Text = "Сериализатор (формат файла):";
            // 
            // ser_choice
            // 
            ser_choice.FormattingEnabled = true;
            ser_choice.Location = new System.Drawing.Point(138, 95);
            ser_choice.Name = "ser_choice";
            ser_choice.Size = new System.Drawing.Size(455, 33);
            ser_choice.TabIndex = 0;
            // 
            // cipher_panel
            // 
            cipher_panel.Controls.Add(label2);
            cipher_panel.Controls.Add(cipher_choice);
            cipher_panel.Location = new System.Drawing.Point(0, 239);
            cipher_panel.Name = "cipher_panel";
            cipher_panel.Size = new System.Drawing.Size(731, 150);
            cipher_panel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(138, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(207, 25);
            label2.TabIndex = 1;
            label2.Text = "Алгоритм шифрования:";
            // 
            // cipher_choice
            // 
            cipher_choice.FormattingEnabled = true;
            cipher_choice.Location = new System.Drawing.Point(138, 95);
            cipher_choice.Name = "cipher_choice";
            cipher_choice.Size = new System.Drawing.Size(455, 33);
            cipher_choice.TabIndex = 0;
            // 
            // cipher_needed
            // 
            cipher_needed.AutoSize = true;
            cipher_needed.Location = new System.Drawing.Point(138, 179);
            cipher_needed.Name = "cipher_needed";
            cipher_needed.Size = new System.Drawing.Size(240, 29);
            cipher_needed.TabIndex = 3;
            cipher_needed.TabStop = true;
            cipher_needed.Text = "шифровать содержимое";
            cipher_needed.UseVisualStyleBackColor = true;
            cipher_needed.CheckedChanged += cipher_needed_CheckedChanged;
            // 
            // save_form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(734, 456);
            Controls.Add(cipher_needed);
            Controls.Add(cipher_panel);
            Controls.Add(serializator_panel);
            Controls.Add(save_button);
            Name = "save_form";
            Text = "save_form";
            Load += save_form_Load;
            serializator_panel.ResumeLayout(false);
            serializator_panel.PerformLayout();
            cipher_panel.ResumeLayout(false);
            cipher_panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Panel serializator_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ser_choice;
        private System.Windows.Forms.Panel cipher_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cipher_choice;
        private System.Windows.Forms.SaveFileDialog save_dlg;
        private System.Windows.Forms.RadioButton cipher_needed;
    }
}