namespace KNNPredictor
{
    partial class KNNPredictor
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._windLabel = new System.Windows.Forms.Label();
            this._powerLabel = new System.Windows.Forms.Label();
            this._windTextBox = new System.Windows.Forms.TextBox();
            this._powerTextBox = new System.Windows.Forms.TextBox();
            this._pitchLabel = new System.Windows.Forms.Label();
            this._selectFileButton = new System.Windows.Forms.Button();
            this._predictButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _windLabel
            // 
            this._windLabel.AutoSize = true;
            this._windLabel.Location = new System.Drawing.Point(46, 32);
            this._windLabel.Name = "_windLabel";
            this._windLabel.Size = new System.Drawing.Size(35, 12);
            this._windLabel.TabIndex = 0;
            this._windLabel.Text = "Winds";
            // 
            // _powerLabel
            // 
            this._powerLabel.AutoSize = true;
            this._powerLabel.Location = new System.Drawing.Point(47, 83);
            this._powerLabel.Name = "_powerLabel";
            this._powerLabel.Size = new System.Drawing.Size(34, 12);
            this._powerLabel.TabIndex = 1;
            this._powerLabel.Text = "Power";
            // 
            // _windTextBox
            // 
            this._windTextBox.Location = new System.Drawing.Point(100, 29);
            this._windTextBox.Name = "_windTextBox";
            this._windTextBox.Size = new System.Drawing.Size(100, 22);
            this._windTextBox.TabIndex = 2;
            // 
            // _powerTextBox
            // 
            this._powerTextBox.Location = new System.Drawing.Point(100, 80);
            this._powerTextBox.Name = "_powerTextBox";
            this._powerTextBox.Size = new System.Drawing.Size(100, 22);
            this._powerTextBox.TabIndex = 3;
            // 
            // _pitchLabel
            // 
            this._pitchLabel.AutoSize = true;
            this._pitchLabel.Location = new System.Drawing.Point(46, 140);
            this._pitchLabel.Name = "_pitchLabel";
            this._pitchLabel.Size = new System.Drawing.Size(37, 12);
            this._pitchLabel.TabIndex = 4;
            this._pitchLabel.Text = "Pitch : ";
            // 
            // _selectFileButton
            // 
            this._selectFileButton.Location = new System.Drawing.Point(254, 83);
            this._selectFileButton.Name = "_selectFileButton";
            this._selectFileButton.Size = new System.Drawing.Size(75, 23);
            this._selectFileButton.TabIndex = 5;
            this._selectFileButton.Text = "Select file";
            this._selectFileButton.UseVisualStyleBackColor = true;
            // 
            // _predictButton
            // 
            this._predictButton.Location = new System.Drawing.Point(254, 135);
            this._predictButton.Name = "_predictButton";
            this._predictButton.Size = new System.Drawing.Size(75, 23);
            this._predictButton.TabIndex = 6;
            this._predictButton.Text = "Predict！";
            this._predictButton.UseVisualStyleBackColor = true;
            // 
            // KNNPredictor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 183);
            this.Controls.Add(this._predictButton);
            this.Controls.Add(this._selectFileButton);
            this.Controls.Add(this._pitchLabel);
            this.Controls.Add(this._powerTextBox);
            this.Controls.Add(this._windTextBox);
            this.Controls.Add(this._powerLabel);
            this.Controls.Add(this._windLabel);
            this.Name = "KNNPredictor";
            this.Text = "KNNPredictor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _windLabel;
        private System.Windows.Forms.Label _powerLabel;
        private System.Windows.Forms.TextBox _windTextBox;
        private System.Windows.Forms.TextBox _powerTextBox;
        private System.Windows.Forms.Label _pitchLabel;
        private System.Windows.Forms.Button _selectFileButton;
        private System.Windows.Forms.Button _predictButton;
    }
}

