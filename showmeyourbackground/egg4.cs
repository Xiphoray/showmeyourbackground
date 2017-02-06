/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/6
 * 时间: 21:20
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace showmeyourbackground
{
	/// <summary>
	/// Description of egg4.
	/// </summary>
	public partial class egg4 : Form
	{
		public egg4()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			timer1.Start();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		int intpercent = 0;
		void timer1_Tick(object sender, EventArgs e)
		{
			progressBar1.PerformStep();
			
			intpercent = progressBar1.Value;
			label1.Text = "数据传输中   " + Convert.ToInt16(intpercent).ToString() + "%";
			if(intpercent == 100)
			{
				timer1.Stop();
				Hide();
				MessageBox.Show("嗯，我已经回去了，谢谢啊 ...... 还有，新年快乐！","",MessageBoxButtons.OK,MessageBoxIcon.Information);
				MessageBox.Show("软件已最小化");
			}
		}
	}
}
