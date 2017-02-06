/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/6
 * 时间: 20:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace showmeyourbackground
{
	partial class egg2
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Timer timer1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(26, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(331, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "^ 太好了，非常感谢！";
			this.label1.Visible = false;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(26, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(326, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "^ 那就长话短说吧 ......";
			this.label2.Visible = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(26, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(341, 47);
			this.label3.TabIndex = 2;
			this.label3.Text = "^ 我觉得只要把连接导回我之前的地址就可以的了 ......";
			this.label3.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(26, 127);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(331, 45);
			this.label4.TabIndex = 3;
			this.label4.Text = " ^ 我记得域名应该是10.13.14.17，输进去就可以的了 ......";
			this.label4.Visible = false;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox1.Location = new System.Drawing.Point(26, 190);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(340, 51);
			this.textBox1.TabIndex = 4;
			this.textBox1.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 900;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// egg2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 284);
			this.ControlBox = false;
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "egg2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
