/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/6
 * 时间: 20:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace showmeyourbackground
{
	/// <summary>
	/// Description of egg2.
	/// </summary>
	public partial class egg2 : Form
	{
		public egg2()
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
			label4.Show ();
			if(a >= 5)
			{
				textBox1.Show();
				if(textBox1.Text == "10.13.14.17")
				{
					timer1.Stop();
					Hide();
					egg3 y = new egg3();
					y.Show();
				}
			}
		}
	}
}
