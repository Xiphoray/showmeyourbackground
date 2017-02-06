/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/6
 * 时间: 20:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace showmeyourbackground
{
	/// <summary>
	/// Description of egg3.
	/// </summary>
	public partial class egg3 : Form
	{
		public egg3()
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
			if(a >=3 )
			{
				radioButton1.Show();
				radioButton2.Show();
				radioButton3.Show();
				radioButton4.Show();
				radioButton5.Show();
				radioButton6.Show();
				radioButton7.Show();
				radioButton8.Show();
				radioButton9.Show();
				timer1.Stop();
				timer2.Start();
			}
		}
		int r = 0;
		void timer2_Tick(object sender, EventArgs e)
		{
			if(r==0)
			{
				if(radioButton3.Checked == true)
					r = 1;
			}
			if(r == 1)
			{
				if(radioButton5.Checked == true)
					r = 2;
			}
			if(r == 2)
			{
				if(radioButton9.Checked  == true)
				{
					timer2.Stop();
					Hide();
					egg4 j = new egg4();
					j.Show();
				}			
			}			
		}
	}
}
