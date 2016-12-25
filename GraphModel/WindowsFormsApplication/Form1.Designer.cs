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
			this.debugLabel.Location = new System.Drawing.Point(500, 55);
			this.debugLabel.Name = "debugLabel";
			this.debugLabel.Size = new System.Drawing.Size(74, 13);
			this.debugLabel.TabIndex = 4;
			this.debugLabel.Text = "<debug label>";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(887, 474);
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
	}
}

