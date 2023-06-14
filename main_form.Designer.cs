
namespace oop_crud
{
    partial class main_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            make_new_button = new System.Windows.Forms.Button();
            curr_element_panel = new System.Windows.Forms.Panel();
            fields_panel = new System.Windows.Forms.Panel();
            user_task_label = new System.Windows.Forms.Label();
            type_field = new System.Windows.Forms.ComboBox();
            controls_panel = new System.Windows.Forms.Panel();
            change_item_panel = new System.Windows.Forms.Panel();
            previous_button = new System.Windows.Forms.Button();
            next_button = new System.Windows.Forms.Button();
            delete_object = new System.Windows.Forms.Button();
            save_object_button = new System.Windows.Forms.Button();
            upper_menu = new System.Windows.Forms.MenuStrip();
            FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SaveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            LoadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            open_dlg = new System.Windows.Forms.OpenFileDialog();
            curr_element_panel.SuspendLayout();
            controls_panel.SuspendLayout();
            change_item_panel.SuspendLayout();
            upper_menu.SuspendLayout();
            SuspendLayout();
            // 
            // make_new_button
            // 
            make_new_button.Location = new System.Drawing.Point(12, 27);
            make_new_button.Name = "make_new_button";
            make_new_button.Size = new System.Drawing.Size(46, 34);
            make_new_button.TabIndex = 0;
            make_new_button.Text = "+";
            make_new_button.UseVisualStyleBackColor = true;
            make_new_button.Click += make_new_button_Click;
            // 
            // curr_element_panel
            // 
            curr_element_panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            curr_element_panel.Controls.Add(fields_panel);
            curr_element_panel.Controls.Add(user_task_label);
            curr_element_panel.Controls.Add(type_field);
            curr_element_panel.Location = new System.Drawing.Point(12, 68);
            curr_element_panel.Name = "curr_element_panel";
            curr_element_panel.Size = new System.Drawing.Size(678, 822);
            curr_element_panel.TabIndex = 1;
            // 
            // fields_panel
            // 
            fields_panel.Location = new System.Drawing.Point(3, 87);
            fields_panel.Name = "fields_panel";
            fields_panel.Size = new System.Drawing.Size(672, 732);
            fields_panel.TabIndex = 2;
            // 
            // user_task_label
            // 
            user_task_label.AutoSize = true;
            user_task_label.Location = new System.Drawing.Point(17, 16);
            user_task_label.Name = "user_task_label";
            user_task_label.Size = new System.Drawing.Size(197, 25);
            user_task_label.TabIndex = 1;
            user_task_label.Text = "Выберите тип изделия:";
            // 
            // type_field
            // 
            type_field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            type_field.FormattingEnabled = true;
            type_field.Location = new System.Drawing.Point(17, 48);
            type_field.Name = "type_field";
            type_field.Size = new System.Drawing.Size(636, 33);
            type_field.Sorted = true;
            type_field.TabIndex = 0;
            type_field.SelectedIndexChanged += type_field_SelectedIndexChanged;
            // 
            // controls_panel
            // 
            controls_panel.Controls.Add(change_item_panel);
            controls_panel.Controls.Add(delete_object);
            controls_panel.Controls.Add(save_object_button);
            controls_panel.Location = new System.Drawing.Point(709, 52);
            controls_panel.Name = "controls_panel";
            controls_panel.Size = new System.Drawing.Size(392, 474);
            controls_panel.TabIndex = 2;
            // 
            // change_item_panel
            // 
            change_item_panel.Controls.Add(previous_button);
            change_item_panel.Controls.Add(next_button);
            change_item_panel.Location = new System.Drawing.Point(18, 130);
            change_item_panel.Name = "change_item_panel";
            change_item_panel.Size = new System.Drawing.Size(355, 70);
            change_item_panel.TabIndex = 2;
            // 
            // previous_button
            // 
            previous_button.Location = new System.Drawing.Point(3, 16);
            previous_button.Name = "previous_button";
            previous_button.Size = new System.Drawing.Size(169, 34);
            previous_button.TabIndex = 1;
            previous_button.Text = "<- предыдущий";
            previous_button.UseVisualStyleBackColor = true;
            previous_button.Click += previous_button_Click;
            // 
            // next_button
            // 
            next_button.Location = new System.Drawing.Point(186, 16);
            next_button.Name = "next_button";
            next_button.Size = new System.Drawing.Size(169, 34);
            next_button.TabIndex = 0;
            next_button.Text = "следующий ->";
            next_button.UseVisualStyleBackColor = true;
            next_button.Click += next_button_Click;
            // 
            // delete_object
            // 
            delete_object.Location = new System.Drawing.Point(18, 66);
            delete_object.Name = "delete_object";
            delete_object.Size = new System.Drawing.Size(355, 34);
            delete_object.TabIndex = 1;
            delete_object.Text = "удалить";
            delete_object.UseVisualStyleBackColor = true;
            delete_object.Click += delete_object_Click;
            // 
            // save_object_button
            // 
            save_object_button.Location = new System.Drawing.Point(18, 16);
            save_object_button.Name = "save_object_button";
            save_object_button.Size = new System.Drawing.Size(355, 34);
            save_object_button.TabIndex = 0;
            save_object_button.Text = "сохранить";
            save_object_button.UseVisualStyleBackColor = true;
            save_object_button.Click += save_object_button_Click;
            // 
            // upper_menu
            // 
            upper_menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            upper_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { FileToolStripMenuItem });
            upper_menu.Location = new System.Drawing.Point(0, 0);
            upper_menu.Name = "upper_menu";
            upper_menu.Size = new System.Drawing.Size(1113, 33);
            upper_menu.TabIndex = 3;
            upper_menu.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveFileToolStripMenuItem, LoadFileToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            FileToolStripMenuItem.Text = "Файл...";
            // 
            // SaveFileToolStripMenuItem
            // 
            SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            SaveFileToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            SaveFileToolStripMenuItem.Text = "сохранить список";
            SaveFileToolStripMenuItem.Click += SaveFileToolStripMenuItem_Click;
            // 
            // LoadFileToolStripMenuItem
            // 
            LoadFileToolStripMenuItem.Name = "LoadFileToolStripMenuItem";
            LoadFileToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            LoadFileToolStripMenuItem.Text = "загрузить список";
            LoadFileToolStripMenuItem.Click += LoadFileToolStripMenuItem_Click;
            // 
            // open_dlg
            // 
            open_dlg.FileName = "open_dlg";
            // 
            // main_form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1113, 902);
            Controls.Add(controls_panel);
            Controls.Add(curr_element_panel);
            Controls.Add(make_new_button);
            Controls.Add(upper_menu);
            MainMenuStrip = upper_menu;
            Name = "main_form";
            Text = "list page";
            Load += main_form_Load;
            Shown += main_form_Shown;
            curr_element_panel.ResumeLayout(false);
            curr_element_panel.PerformLayout();
            controls_panel.ResumeLayout(false);
            change_item_panel.ResumeLayout(false);
            upper_menu.ResumeLayout(false);
            upper_menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button make_new_button;
        private System.Windows.Forms.Panel curr_element_panel;
        private System.Windows.Forms.Panel controls_panel;
        private System.Windows.Forms.Panel change_item_panel;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button delete_object;
        private System.Windows.Forms.Button save_object_button;
        private System.Windows.Forms.Label user_task_label;
        private System.Windows.Forms.ComboBox type_field;
        private System.Windows.Forms.Panel fields_panel;
        private System.Windows.Forms.MenuStrip upper_menu;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog open_dlg;
    }
}

