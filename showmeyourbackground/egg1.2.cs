/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/6
 * 时间: 18:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace showmeyourbackground
{
	/// <summary>
	/// Description of egg1_2.
	/// </summary>
	public partial class egg1_2 : Form
	{
		public egg1_2()
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
		public int a = 0;
		void timer1_Tick(object sender, EventArgs e)
		{
			a++;
			if(a == 1)
			label1.Visible = true;
			if(a == 2)
			label2.Show();
			if(a == 3)
			label3.Show();
			if(a == 4)
			{
			button1.Show();
			button2.Show();
			
			timer1.Stop();
			}
		}
		void button2_Click(object sender, EventArgs e)
		{
			Hide();
			MessageBox.Show("不明链接已断开","",MessageBoxButtons.OK,MessageBoxIcon.Information);
			MessageBox.Show("软件已最小化");
		}
		void button1_Click(object sender, EventArgs e)
		{
			Hide();
			egg2 w = new egg2();
			w.Show();
		}
	}
}
