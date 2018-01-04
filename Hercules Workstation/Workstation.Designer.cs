namespace Hercules_Workstation
{
    partial class HerculesWorkstation
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
            this.statusLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.finishBtn = new System.Windows.Forms.Button();
            this.requestBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.Red;
            this.statusLbl.Location = new System.Drawing.Point(12, 404);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(96, 18);
            this.statusLbl.TabIndex = 1;
            this.statusLbl.Text = "Status: Good";
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(293, 300);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(112, 53);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // finishBtn
            // 
            this.finishBtn.Enabled = false;
            this.finishBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishBtn.Location = new System.Drawing.Point(424, 300);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(112, 53);
            this.finishBtn.TabIndex = 3;
            this.finishBtn.Text = "FINISH";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // requestBtn
            // 
            this.requestBtn.Enabled = false;
            this.requestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestBtn.Location = new System.Drawing.Point(15, 300);
            this.requestBtn.Name = "requestBtn";
            this.requestBtn.Size = new System.Drawing.Size(112, 53);
            this.requestBtn.TabIndex = 4;
            this.requestBtn.Text = "REQUEST A JOB";
            this.requestBtn.UseVisualStyleBackColor = true;
            this.requestBtn.Click += new System.EventHandler(this.requestBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(148, 300);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(123, 53);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "CANCEL REQUEST";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // HerculesWorkstation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 429);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.requestBtn);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.statusLbl);
            this.Name = "HerculesWorkstation";
            this.Text = "Hercules Workstation";
            this.Load += new System.EventHandler(this.HerculesWorkstation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Button requestBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}

