/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/26
 * 时间: 10:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace showmeyourbackground
{
	/// <summary>
	/// Description of NoPic.
	/// </summary>
	public partial class NoPic : Form
	{
		public NoPic()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			timer1 .Start ();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			timer2 .Start ();
		}
		void timer2_Tick(object sender, EventArgs e)
		{
			if (Opacity > 0 && Opacity <= 1)//开始执行弹出窗渐渐透明  
		       {  
		              Opacity = Opacity - 0.05;//透明频度0.05  
		       }
			if(Opacity == 0)
			{
				timer2 .Stop ();
				Dispose();                //释放资源
				Close();
			}
			if (Control.MousePosition.X >= Location.X && Control.MousePosition.Y >= Location.Y)
			{
				Opacity = 1;
				timer2 .Stop();
				timer1 .Start();
			}
		}
	}
}
