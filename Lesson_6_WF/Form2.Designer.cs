namespace Lesson_6_WF
{
    partial class Form2
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
            this.bt_load = new System.Windows.Forms.Button();
            this.bt_show_one = new System.Windows.Forms.Button();
            this.bt_show_all = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(23, 11);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(139, 23);
            this.bt_load.TabIndex = 0;
            this.bt_load.Text = "Load Picture";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // bt_show_one
            // 
            this.bt_show_one.Location = new System.Drawing.Point(168, 12);
            this.bt_show_one.Name = "bt_show_one";
            this.bt_show_one.Size = new System.Drawing.Size(144, 23);
            this.bt_show_one.TabIndex = 1;
            this.bt_show_one.Text = "Show One";
            this.bt_show_one.UseVisualStyleBackColor = true;
            this.bt_show_one.Click += new System.EventHandler(this.bt_show_one_Click);
            // 
            // bt_show_all
            // 
            this.bt_show_all.Location = new System.Drawing.Point(629, 11);
            this.bt_show_all.Name = "bt_show_all";
            this.bt_show_all.Size = new System.Drawing.Size(116, 23);
            this.bt_show_all.TabIndex = 2;
            this.bt_show_all.Text = "Show All";
            this.bt_show_all.UseVisualStyleBackColor = true;
            this.bt_show_all.Click += new System.EventHandler(this.bt_show_all_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(318, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 22);
            this.textBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(336, 369);
            this.dataGridView1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(392, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 369);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_show_all);
            this.Controls.Add(this.bt_show_one);
            this.Controls.Add(this.bt_load);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Button bt_show_one;
        private System.Windows.Forms.Button bt_show_all;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}