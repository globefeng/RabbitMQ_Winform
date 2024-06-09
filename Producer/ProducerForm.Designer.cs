namespace Producer
{
    partial class ProducerForm
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
            this.Queue = new System.Windows.Forms.Label();
            this.tbxQueue = new System.Windows.Forms.TextBox();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Queue
            // 
            this.Queue.AutoSize = true;
            this.Queue.Location = new System.Drawing.Point(99, 48);
            this.Queue.Name = "Queue";
            this.Queue.Size = new System.Drawing.Size(78, 32);
            this.Queue.TabIndex = 0;
            this.Queue.Text = "label1";
            // 
            // tbxQueue
            // 
            this.tbxQueue.Location = new System.Drawing.Point(208, 48);
            this.tbxQueue.Name = "tbxQueue";
            this.tbxQueue.Size = new System.Drawing.Size(482, 39);
            this.tbxQueue.TabIndex = 1;
            this.tbxQueue.Text = "queue1";
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(99, 122);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(591, 243);
            this.tbxMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(296, 405);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(150, 46);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ProducerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.tbxQueue);
            this.Controls.Add(this.Queue);
            this.Name = "ProducerForm";
            this.Text = "ProducerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProducerForm_FormClosed);
            this.Load += new System.EventHandler(this.ProducerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Queue;
        private System.Windows.Forms.TextBox tbxQueue;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Button btnSend;
    }
}