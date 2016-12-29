namespace WindowsFormsApplication {
	partial class Form1 {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.loadGraphButton = new System.Windows.Forms.Button();
			this.graphBox = new System.Windows.Forms.GroupBox();
			this.loadExampleButton = new System.Windows.Forms.Button();
			this.debugLabel = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.saveButtonLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// loadGraphButton
			// 
			this.loadGraphButton.Location = new System.Drawing.Point(28, 26);
			this.loadGraphButton.Name = "loadGraphButton";
			this.loadGraphButton.Size = new System.Drawing.Size(104, 23);
			this.loadGraphButton.TabIndex = 0;
			this.loadGraphButton.Text = "Открыть граф";
			this.loadGraphButton.UseVisualStyleBackColor = true;
			this.loadGraphButton.Click += new System.EventHandler(this.loadGraphButton_Click);
			// 
			// graphBox
			// 
			this.graphBox.Location = new System.Drawing.Point(50, 96);
			this.graphBox.Name = "graphBox";
			this.graphBox.Size = new System.Drawing.Size(804, 336);
			this.graphBox.TabIndex = 2;
			this.graphBox.TabStop = false;
			// 
			// loadExampleButton
			// 
			this.loadExampleButton.Location = new System.Drawing.Point(28, 55);
			this.loadExampleButton.Name = "loadExampleButton";
			this.loadExampleButton.Size = new System.Drawing.Size(104, 23);
			this.loadExampleButton.TabIndex = 3;
			this.loadExampleButton.Text = "Открыть пример";
			this.loadExampleButton.UseVisualStyleBackColor = true;
			this.loadExampleButton.Click += new System.EventHandler(this.loadExampleButton_Click);
			// 
			// debugLabel
			// 
			this.debugLabel.AutoSize = true;
			this.debugLabel.Location = new System.Drawing.Point(591, 452);
			this.debugLabel.Name = "debugLabel";
			this.debugLabel.Size = new System.Drawing.Size(74, 13);
			this.debugLabel.TabIndex = 4;
			this.debugLabel.Text = "<debug label>";
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(195, 26);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 5;
			this.saveButton.Text = "Сохранить";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveButtonLabel
			// 
			this.saveButtonLabel.AutoSize = true;
			this.saveButtonLabel.Location = new System.Drawing.Point(277, 35);
			this.saveButtonLabel.Name = "saveButtonLabel";
			this.saveButtonLabel.Size = new System.Drawing.Size(0, 13);
			this.saveButtonLabel.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(887, 474);
			this.Controls.Add(this.saveButtonLabel);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.debugLabel);
			this.Controls.Add(this.loadExampleButton);
			this.Controls.Add(this.graphBox);
			this.Controls.Add(this.loadGraphButton);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button loadGraphButton;
		private System.Windows.Forms.GroupBox graphBox;
		private System.Windows.Forms.Button loadExampleButton;
		private System.Windows.Forms.Label debugLabel;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label saveButtonLabel;
	}
}

