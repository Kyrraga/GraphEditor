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
			this.drawButon = new System.Windows.Forms.Button();
			this.graphBox = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// loadGraphButton
			// 
			this.loadGraphButton.Location = new System.Drawing.Point(28, 26);
			this.loadGraphButton.Name = "loadGraphButton";
			this.loadGraphButton.Size = new System.Drawing.Size(90, 23);
			this.loadGraphButton.TabIndex = 0;
			this.loadGraphButton.Text = "Открыть граф";
			this.loadGraphButton.UseVisualStyleBackColor = true;
			this.loadGraphButton.Click += new System.EventHandler(this.loadGraphButton_Click);
			// 
			// drawButon
			// 
			this.drawButon.Location = new System.Drawing.Point(333, 25);
			this.drawButon.Name = "drawButon";
			this.drawButon.Size = new System.Drawing.Size(111, 23);
			this.drawButon.TabIndex = 1;
			this.drawButon.Text = "Нарисовать граф";
			this.drawButon.UseVisualStyleBackColor = true;
			this.drawButon.Click += new System.EventHandler(this.drawButon_Click);
			// 
			// graphBox
			// 
			this.graphBox.Location = new System.Drawing.Point(50, 96);
			this.graphBox.Name = "graphBox";
			this.graphBox.Size = new System.Drawing.Size(804, 336);
			this.graphBox.TabIndex = 2;
			this.graphBox.TabStop = false;
			this.graphBox.Paint += new System.Windows.Forms.PaintEventHandler(this.graphBox_Paint);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(887, 474);
			this.Controls.Add(this.graphBox);
			this.Controls.Add(this.drawButon);
			this.Controls.Add(this.loadGraphButton);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button loadGraphButton;
		private System.Windows.Forms.Button drawButon;
		private System.Windows.Forms.GroupBox graphBox;
	}
}

