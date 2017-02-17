/*
 * 由SharpDevelop创建。
 * 用户： Xiphoray
 * 日期: 2017/2/4
 * 时间: 09:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Microsoft.Win32;



namespace showmeyourbackground
{
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			init();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
		static extern int SystemParametersInfo                                 //注册表写入的东西，不要改
		(
			int uAction,
			int uParam,
			string lpvParam,
			int fuWinIni
		);
		void button2_Click(object sender, EventArgs e) //运行按键 
		{
			label1.Show();
			button2.Hide();
			comboBox2.Hide();
			comboBox1.Hide();
			workingflag = true ;
			work();
			this.timer1.Start();
		}
		void timer1_Tick(object sender, EventArgs e)  //计时器
		{
			work();
		}
		void Form1_FormClosing(object sender, FormClosingEventArgs e)  //关闭主框架时提示
		{
			if(workingflag == true )
			{
				//窗体关闭原因为单击"关闭"按钮或Alt+F4
				if (e.CloseReason == CloseReason.UserClosing)
				 {
				 	e.Cancel = true;           //取消关闭操作 表现为不关闭窗体
				 	notifyIcon1.Visible = true;   //设置图标可见
				        this.Hide();               //隐藏窗体
				        MessageBox.Show("SMYB已被你打入冷宫","",MessageBoxButtons.OK,MessageBoxIcon.Information);
				  }
			}
			else 
			{
				//点击"是(YES)"退出程序
			    if (MessageBox.Show("确定要离开?", "",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
			    {
			        notifyIcon1.Visible = false;   //设置图标不可见
			        this.Dispose();                //释放资源
			        Application.Exit();            //关闭应用程序窗体
			    }
			    else
			    {
			    	e.Cancel = true;           //取消关闭操作 表现为不关闭窗体
			    }
			}
		}
		void button1_Click(object sender, EventArgs e) //彩蛋按键
		{
			button1.Hide ();
			this.Hide();
			notifyIcon1.Visible = true;
			egg();
		}
		void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//点击"是(YES)"退出程序
			    if (MessageBox.Show("确定要离开?", "",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
			    {
			        notifyIcon1.Visible = false;   //设置图标不可见
			        this.Dispose();                //释放资源
			        Application.Exit();            //关闭应用程序窗体
			    }
		}
		void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			workingflag = false;
			button2.Show ();
			comboBox1.Show();
			label1.Hide ();
			this.Show();                                //窗体显示
		        this.WindowState = FormWindowState.Normal;  //窗体状态默认大小
		        this.Activate();                            //激活窗体给予焦点
		}
		void 下一张ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			work();
			timer1.Stop();
			timer1.Start();
		}
		void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			//双击鼠标"左键"发生
			    if (e.Button == MouseButtons.Left)
			    {
			        this.Visible = true;                        //窗体可见
			        this.WindowState = FormWindowState.Normal;  //窗体默认大小
			        this.notifyIcon1.Visible = true;            //设置图标可见
			    }
		}
		void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  //时间控制
		{
			string ChangeTimeS = comboBox1.Text;
			ChangeTimeS = ChangeTimeS.Substring(0,ChangeTimeS.Length-2);
			int ChangeTimeI = Convert.ToInt16(ChangeTimeS);
			timer1.Interval = ChangeTimeI * 60000;
		}
		void comboBox2_SelectedIndexChanged(object sender, EventArgs e)  //类别控制
		{
			switch(comboBox2 .Text)
			{
				case "无限制":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&cat=&order=latest&orientation=horizontal";
					break;
				case "建筑":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&orientation=horizontal&order=latest&cat=buildings";
					break;
				case "动物":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&cat=animals&orientation=horizontal&order=latest";
					break;
				case "自然":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&order=latest&orientation=horizontal&cat=nature";
					break;
				case "人物":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&cat=people&order=latest&orientation=horizontal";
					break;
				case "宗教":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&orientation=horizontal&order=latest&cat=religion";
					break;
				case "旅行":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&cat=travel&orientation=horizontal&order=latest";
					break;
				case "静物":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&order=latest&orientation=horizontal&cat=backgrounds";
					break;
				case "名胜":
					mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&cat=places&order=latest&orientation=horizontal";
					break;
			}
			
			GetHtmlStrNet(mainurl,"UTF8");
		}
		
		
		public static bool workingflag = false ;
		public static string mainurl;
		/// <summary>  
		/// 初始化  
		/// </summary>    
		public void init()
		{

			if (Directory.Exists(Define.datafiles) == false)//如果不存在就创建file文件夹
		         {
		             Directory.CreateDirectory(Define.datafiles);
		         }
			if (Directory.Exists(Define.Picfiles ) == false)//如果不存在就创建file文件夹
		         {
		             Directory.CreateDirectory(Define.Picfiles );
		         }
			if (Directory.Exists(Define.Imgfiles ) == false)//如果不存在就创建file文件夹
		         {
		             Directory.CreateDirectory(Define.Imgfiles);
		         }
			if(!File.Exists(Define.eggtext))
			{
				File.WriteAllText(Define.eggtext,"");
				
			}
			if(!File.Exists(Define.Htmltext))
			{
				File.WriteAllText(Define.Htmltext,"");
			}
			workingflag = false ;
			mainurl = @"https://pixabay.com/en/photos/?q=&image_type=photo&cat=&order=latest&orientation=horizontal";
			 RegistryKey hk = Registry.CurrentUser;
			RegistryKey run = hk.CreateSubKey(@"Control Panel\Desktop\");
			run.SetValue("TileWallpaper", "0");//0 居中 1  平铺 默认
            		run.SetValue("WallpaperStyle", "0");//2 拉伸
			RegistryKey ak = Registry.CurrentUser;
			RegistryKey ran = hk.CreateSubKey(@"Control Panel\Personalization\Desktop Slideshow");
			ran.SetValue("AnimationDuration",4500);
			run.Close();
			ran.Close();
			if(coloreggcheck())
				button1.Show();
			comboBox1.SelectedIndex = 3;
			comboBox2.SelectedIndex = 0;
		}
		
		/// <summary>  
		/// 运行
		/// </summary>    
		public void work()
		{
			
			string mhtml,pichtml,picurl,htmlurl;
			if(isConn())
			{
				try
				{
					mhtml = GetHtmlStrLoc();
					htmlurl = GetHtmlURI(mhtml,@"div class=""item""","a href");
					if(htmlurl == "https://pixabay.com")
					{
						mhtml = GetHtmlStrNet(mainurl,"UTF8");
						htmlurl = GetHtmlURI(mhtml,@"div class=""item""","a href");
					}
					pichtml = GetHtmlStr(htmlurl,"UTF8");
					picurl = GetPicURI(pichtml,@"img itemprop=""contentURL""");
					if(DownloadCheck(picurl))
					{
						Changepaperwall(SaveAsWebImg(picurl));
					}
				}
				catch(Exception)
				{
					GetLocImg();
				}
			}
			else
			{
				GetLocImg();
			}
		}
		
		/// <summary>  
		/// 更改壁纸  
		/// </summary>  
		/// <param name="picPath">图片文件地址</param>   
		public void Changepaperwall(string picPath)
		{
			string strSavePath = picPath;
		       RegistryKey hk = Registry.CurrentUser;
			RegistryKey run = hk.CreateSubKey(@"Control Panel\Desktop\");
			run.SetValue("Wallpaper", strSavePath); //将新图片路径写入注册表
			run.Close();
		       SystemParametersInfo(20, 1, strSavePath, 0x1);//SPI_SETDESKWALLPAPER
		       
		}
		
		/// <summary>  
		/// 随机选择图片
		/// </summary>  
		/// <returns>图片文件地址</returns> 
		public void GetLocImg()
		{
			string filepath = Define.ImgPath;
			string [] filenames=Directory.GetFiles(filepath);  //获取该文件夹下面的所有文件名   
			int Imgnum = filenames.Length;
			Random ra = new Random();
			int ran = ra.Next(0,Imgnum);
			Changepaperwall((string)filenames.GetValue(ran));
		}
		
		/// <summary>  
		/// 判断下载图片是否符合要求  
		/// </summary>  
		/// <param name="picUrl">图片链接地址</param>   
		/// <returns>真假值</returns> 
		public bool DownloadCheck(string picUrl)
		{
			long size = GetHttpLength(picUrl);
			if(size > 1024*100)
				return true;
			else 
				return false;
		}
		
		/// <summary>  
		/// 获取下载文件的大小  
		/// </summary>  
		/// <param name="url">链接地址</param>   
		/// <returns>文件大小</returns> 
		static long GetHttpLength(string url)
		{
		    var length = 0L;
		    try
		    {
		        var req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
		        req.Method = "HEAD"; 
		        req.Timeout = 5000; 
		        var res = (HttpWebResponse)req.GetResponse();
		        if (res.StatusCode == HttpStatusCode.OK)
		        {
		            length =  res.ContentLength;  
		        }
		        res.Close();
		        return length;
		    } 
		    catch (WebException)
		    {
		    	//MessageBox.Show(ex.Message);
		        return 0;
		    }
		}
		
		/// <summary>  
		/// 获取网页的HTML码
		/// </summary>  
		/// <param name="url">链接地址</param>  
		/// <param name="encoding">编码类型</param>  
		/// <returns>html码</returns>  
		public static string GetHtmlStr(string url, string encoding)  
		{  
		    string htmlStr = "";  
		    if (!String.IsNullOrEmpty(url))  
		    {  
		        WebRequest request = WebRequest.Create(url);            //实例化WebRequest对象  
		        WebResponse response = request.GetResponse();           //创建WebResponse对象  
		        Stream datastream = response.GetResponseStream();       //创建流对象  
		        Encoding ec = Encoding.Default;  
		        if (encoding == "UTF8")  
		        {  
		            ec = Encoding.UTF8;  
		        }  
		        else if (encoding == "Default")  
		        {  
		            ec = Encoding.Default;  
		        }  
		        StreamReader reader = new StreamReader(datastream, ec);  
		        htmlStr = reader.ReadToEnd();                           //读取数据  
		        reader.Close();  
		        datastream.Close();  
		        response.Close();  
		    }  
		    return htmlStr;  
		}
		
		/// <summary>  
		/// 获取主网页的HTML码至htmltext.txt文件
		/// </summary>  
		/// <param name="url">链接地址</param>  
		/// <param name="encoding">编码类型</param>  
		/// <returns>html码</returns>  
		public static string GetHtmlStrNet(string url, string encoding)  
		{  
		    string htmlStr = "";  
		    if (!String.IsNullOrEmpty(url))  
		    {  
		        WebRequest request = WebRequest.Create(url);            //实例化WebRequest对象  
		        WebResponse response = request.GetResponse();           //创建WebResponse对象  
		        Stream datastream = response.GetResponseStream();       //创建流对象  
		        Encoding ec = Encoding.Default;  
		        if (encoding == "UTF8")  
		        {  
		            ec = Encoding.UTF8;  
		        }  
		        else if (encoding == "Default")  
		        {  
		            ec = Encoding.Default;  
		        }  
		        StreamReader reader = new StreamReader(datastream, ec);  
		        htmlStr = reader.ReadToEnd();                           //读取数据  
		        reader.Close();  
		        datastream.Close();  
		        response.Close();  
		        
		        string pathString = Define.Htmltext;
			StreamWriter writer = new StreamWriter(pathString,false,Encoding.Default);
			writer.WriteLine(htmlStr);
			writer.Close();
		    }  
		    return htmlStr;  
		}
		
		/// <summary>  
		/// 从htmltext.txt中导出html码  
	       /// </summary>  
	          /// <returns>主html码</returns>
	          public static string GetHtmlStrLoc()
	          {
	          	string pathString = Define.Htmltext;
	          	string htmlStr = "";
	          	try
	          	{
		          	StreamReader reader = new StreamReader(pathString,Encoding.Default);
		          	while(!reader.EndOfStream)
		          	{
		          		htmlStr += reader.ReadLine();
		          	}
		          	reader.Close();
		          	return htmlStr;
	          	}
	          	catch(Exception)
	          	{
	          		//MessageBox.Show(ex.Message);
	          		return null;
	          		
	          	}
	          }
	          
	          /// <summary> 
		/// 获取主网页html里的URI  
	       /// </summary>  
	          /// <param name="str">字符串</param>  
	          /// <param name="title">标签</param>  
	         /// <param name="attrib">属性名</param>  
	          /// <returns>主html里的URI</returns>  
	          public static string GetHtmlURI(string str, string title,string attrib)  
	         {  
	   
	            string tmpStr = string.Format("<{0}[^>]*>\\s*<{1}=(\")(?<url>[^'\"]*)(\")>", title, attrib); 
	            Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);  
	   
	             string result = "https://pixabay.com"+TitleMatch.Groups["url"].Value;  
	             Regex reg = new Regex(tmpStr);
	             string refleshhtml = reg.Replace (str,"a",1);
	              string pathString = Define.Htmltext;
			StreamWriter writer = new StreamWriter(pathString,false,System.Text.Encoding.Default);
			writer.WriteLine(refleshhtml);
			writer.Close();
	             return result;  
	         }  
	          
	          /// <summary>  
		/// 获取图片网页的HTML码
		/// </summary>  
		/// <param name="url">链接地址</param>  
		/// <param name="encoding">编码类型</param>  
		/// <returns>html码</returns>  
		public static string GetPicHtmlStr(string url, string encoding)  
		{  
		    string htmlStr = "";  
		    if (!String.IsNullOrEmpty(url))  
		    {  
		        WebRequest request = WebRequest.Create(url);            //实例化WebRequest对象  
		        WebResponse response = request.GetResponse();           //创建WebResponse对象  
		        Stream datastream = response.GetResponseStream();       //创建流对象  
		        Encoding ec = Encoding.Default;  
		        if (encoding == "UTF8")  
		        {  
		            ec = Encoding.UTF8;  
		        }  
		        else if (encoding == "Default")  
		        {  
		            ec = Encoding.Default;  
		        }  
		        StreamReader reader = new StreamReader(datastream, ec);  
		        htmlStr = reader.ReadToEnd();                           //读取数据  
		        reader.Close();  
		        datastream.Close();  
		        response.Close();  
		    }  
		    return htmlStr;  
		}
		
		/// 获取图片网页html里的picURI  
	       /// </summary>  
	          /// <param name="str">字符串</param>  
	          /// <param name="title">标签</param>    
	          /// <returns>picURI</returns>  
	          public static string GetPicURI(string str, string title)  
	         {  
	   
	            string tmpStr = string.Format("<{0}[^\"]*(\")[^,]*,(?<url>[^'\"]*)(\")\\s*src", title); 
	            Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);  
	   
	             string result = TitleMatch.Groups["url"].Value;  
	             result = result.Substring(0,result.Length-3);
	             return result;  
	         }  
	          
	          /// <summary>  
		/// 彩蛋
		/// </summary>  
		public void egg()
		{
			string pathString = Define.eggtext;
			StreamWriter writer = new StreamWriter(pathString,false,Encoding.Default);
			writer.WriteLine("hehehehe233");
			writer.Close();
			MessageBox.Show("错误（0x23333）  系统数据遭外来文件破环，请重启恢复，或联系厂商","警告",MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Error);
			System.Threading.Thread.Sleep(2000);
			egg eggs1 = new showmeyourbackground.egg();
			eggs1.Show();
			
		}
		
	           /// <summary>  
		/// 判断是否联网
		/// </summary>  
		/// <returns>真假值</returns> 
	        public bool isConn()
	        {
	            System.Net.NetworkInformation.Ping ping;
	            System.Net.NetworkInformation.PingReply res;
	            ping = new System.Net.NetworkInformation.Ping();
	            try
	            {
	                res = ping.Send("www.baidu.com");
	                if (res.Status != System.Net.NetworkInformation.IPStatus.Success)
	                    return false;
	                else
	                    return true;
	            }
	            catch (Exception)
	            {
	                return false;
	            }
	        }
	        
	        /// <summary>
	        /// 下载并保存图片
	       /// </summary>  
	          /// <param name="picUrl">图片地址</param>  
	          /// <returns>图片文件地址</returns>
	        public string SaveAsWebImg(string picUrl)  
		{  
		    string result = "";  
		    string path = Define.PicPath;  //目录  
		    try  
		    {  
		        if (!String.IsNullOrEmpty(picUrl))  
		        {  
		            Random rd = new Random();  
		            DateTime nowTime = DateTime.Now;  
		            string fileName = nowTime.Month.ToString() + nowTime.Day.ToString() + nowTime.Hour.ToString() + nowTime.Minute.ToString() + nowTime.Second.ToString() + rd.Next(1000, 1000000) + ".jpeg";  
		            WebClient webClient = new WebClient();  
		            webClient.DownloadFile(picUrl, path + fileName);  
		            result = Define.ImgPath + fileName;  
		            ChangePic(fileName);
		        }  
		    }  
		    catch(Exception) 
		    { 
		    	GetLocImg();
		    }
		    return result;  
		}
	        
	         /// <summary>
	        /// 缩放图片
	       /// </summary>  
	          /// <param name="Picpath">图片文件地址</param>  
	        public void ChangePic(string Picpath)
	        {
	        	int SH = Screen.PrimaryScreen.Bounds.Height;
			int SW = Screen.PrimaryScreen.Bounds.Width;
			Image pic=Image.FromFile(Define.PicPath + Picpath);//strFilePath是该图片的绝对路径
			int PW=pic.Width;//长度像素值
			int PH=pic.Height;//高度像素值 
			if((PH * SW)/PW >= SH)
			{
				Bitmap repic = new Bitmap(pic,SW,(PH*SW)/PW);
				repic.Save(Define.ImgPath + Picpath);
				repic.Dispose();
			}
			else
			{
				Bitmap repic = new Bitmap(pic,(PW*SH)/PH,SH);
				repic.Save(Define.ImgPath + Picpath);
				repic.Dispose();
			}
			pic.Dispose();
			File.Delete(Define.PicPath + Picpath);
	        }
	        
		 /// <summary>
	        /// 彩蛋检测
	       /// </summary>  
	          /// <returns>真假值</returns>
	          public bool coloreggcheck()
	          {
	          	string pathString = Define.eggtext;
	          	string htmlStr = "";
		          StreamReader reader = new StreamReader(pathString,Encoding.Default);
		          while(!reader.EndOfStream)
		          {
		          	htmlStr += reader.ReadLine();
		          }
		          reader.Close();
		          if(htmlStr == "")
		          	return true;
		          else
		          	return false;
	          }
		
		
		
		
	}
	public static class Define
	{
		public static string datafiles = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +@"data";
		public static string Imgfiles = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"File";
		public static string Picfiles = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Pic";
		public static string Htmltext = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +@"data\htmltext.txt";
		public static string eggtext = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"data\egg.txt";
		public static string  ImgPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"File\";
		public static string  PicPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Pic\";
		
	}
}
