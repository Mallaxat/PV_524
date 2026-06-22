namespace Lesson_911_Asyn
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_fill = new System.Windows.Forms.Button();
            this.bt_update = new System.Windows.Forms.Button();
            this.bt_async = new System.Windows.Forms.Button();
            this.bt_async_wait_handle = new System.Windows.Forms.Button();
            this.bt_async2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(568, 22);
            this.textBox1.TabIndex = 0;
            // 
            // bt_fill
            // 
            this.bt_fill.Location = new System.Drawing.Point(151, 165);
            this.bt_fill.Name = "bt_fill";
            this.bt_fill.Size = new System.Drawing.Size(75, 23);
            this.bt_fill.TabIndex = 1;
            this.bt_fill.Text = "FILL";
            this.bt_fill.UseVisualStyleBackColor = true;
            // 
            // bt_update
            // 
            this.bt_update.Location = new System.Drawing.Point(259, 165);
            this.bt_update.Name = "bt_update";
            this.bt_update.Size = new System.Drawing.Size(75, 23);
            this.bt_update.TabIndex = 2;
            this.bt_update.Text = "UPDATE";
            this.bt_update.UseVisualStyleBackColor = true;
            // 
            // bt_async
            // 
            this.bt_async.Location = new System.Drawing.Point(351, 165);
            this.bt_async.Name = "bt_async";
            this.bt_async.Size = new System.Drawing.Size(75, 23);
            this.bt_async.TabIndex = 3;
            this.bt_async.Text = "ASYN";
            this.bt_async.UseVisualStyleBackColor = true;
            // 
            // bt_async_wait_handle
            // 
            this.bt_async_wait_handle.Location = new System.Drawing.Point(451, 165);
            this.bt_async_wait_handle.Name = "bt_async_wait_handle";
            this.bt_async_wait_handle.Size = new System.Drawing.Size(152, 23);
            this.bt_async_wait_handle.TabIndex = 4;
            this.bt_async_wait_handle.Text = "AsyncWaitHandle";
            this.bt_async_wait_handle.UseVisualStyleBackColor = true;
            // 
            // bt_async2
            // 
            this.bt_async2.Location = new System.Drawing.Point(644, 165);
            this.bt_async2.Name = "bt_async2";
            this.bt_async2.Size = new System.Drawing.Size(75, 23);
            this.bt_async2.TabIndex = 5;
            this.bt_async2.Text = "ASYNC2";
            this.bt_async2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(151, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(725, 315);
            this.dataGridView1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 614);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bt_async2);
            this.Controls.Add(this.bt_async_wait_handle);
            this.Controls.Add(this.bt_async);
            this.Controls.Add(this.bt_update);
            this.Controls.Add(this.bt_fill);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_fill;
        private System.Windows.Forms.Button bt_update;
        private System.Windows.Forms.Button bt_async;
        private System.Windows.Forms.Button bt_async_wait_handle;
        private System.Windows.Forms.Button bt_async2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

