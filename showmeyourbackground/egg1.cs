/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/6
 * 时间: 15:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace showmeyourbackground
{
	/// <summary>
	/// Description of egg1.
	/// </summary>
	public partial class egg1 : Form
	{
		public egg1()
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
			label5.Show();
			if(a == 5)
			label4.Show();
			if(a == 6)
			label6.Show();
			if(a == 7)
			label7.Show();
			if(a == 8)
			label8.Show();
			if(a == 9)
			label9.Show();
			if(a == 10)
			label10.Show ();
			if(a == 11)
			label11.Show();
			if(a == 12)
			label12.Show();
			if(a == 13)
			{
			button1.Show();
			button2.Show();
			timer1.Stop();
			}
		}
		void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			egg1_2 q = new egg1_2();
			q.Show();
		}
		void button1_Click(object sender, EventArgs e)
		{
			Hide();
			egg2 w = new egg2();
			w.Show();
		}
		

	}
}
