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
		static extern int SystemParametersInfo
		(
			int uAction,
			int uParam,
			string lpvParam,
			int fuWinIni
		);
		void button2_Click(object sender, EventArgs e)
		{
			this.timer1.Start();
		}
		void timer1_Tick(object sender, EventArgs e)
		{
			string mainurl = "https://pixabay.com/en/photos/?order=popular";
			string mhtml,pichtml,picurl,htmlurl;
			if(isConn())
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
			
		}
		
		
		/// <summary>  
		/// 初始化  
		/// </summary>    
		public void init()
		{
			
			if(!File.Exists(Define.Htmltext))
			{
				File.Create(Define.Htmltext);
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
			run.SetValue("TileWallpaper", "0");//0 居中 1  平铺 默认
            		run.SetValue("WallpaperStyle", "0");//2 拉伸
            		
		       SystemParametersInfo(20, 1, strSavePath, 0x1);//SPI_SETDESKWALLPAPER
		       run.Close();
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
		    catch (WebException ex)
		    {
		    	MessageBox.Show(ex.Message);
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
			StreamWriter writer = new StreamWriter(pathString,false,System.Text.Encoding.Default);
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
		          	StreamReader reader = new StreamReader(pathString,System.Text.Encoding.Default);
		          	while(!reader.EndOfStream)
		          	{
		          		htmlStr += reader.ReadLine();
		          	}
		          	reader.Close();
		          	return htmlStr;
	          	}
	          	catch(Exception ex)
	          	{
	          		MessageBox.Show(ex.Message);
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
	            catch (Exception ex)
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
		    string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"File/";  //目录  
		    try  
		    {  
		        if (!String.IsNullOrEmpty(picUrl))  
		        {  
		            Random rd = new Random();  
		            DateTime nowTime = DateTime.Now;  
		            string fileName = nowTime.Month.ToString() + nowTime.Day.ToString() + nowTime.Hour.ToString() + nowTime.Minute.ToString() + nowTime.Second.ToString() + rd.Next(1000, 1000000) + ".jpeg";  
		            WebClient webClient = new WebClient();  
		            webClient.DownloadFile(picUrl, path + fileName);  
		            result = path + fileName;  
		        }  
		    }  
		    catch(Exception ex) {MessageBox.Show(ex.Message); }
		    return result;  
		}
		void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			//窗体关闭原因为单击"关闭"按钮或Alt+F4
			if (e.CloseReason == CloseReason.UserClosing)
			 {
			 	e.Cancel = true;           //取消关闭操作 表现为不关闭窗体
			 	notifyIcon1.Visible = true;   //设置图标可见
			        this.Hide();               //隐藏窗体
			        MessageBox.Show("已最小化至面板","",MessageBoxButtons.OK,MessageBoxIcon.Information);
			  }
		}
		void 主页面ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Show();                                //窗体显示
			this.WindowState = FormWindowState.Normal;  //窗体状态默认大小
			this.Activate();                            //激活窗体给予焦点
		}
		void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//点击"是(YES)"退出程序
			    if (MessageBox.Show("确定要退出程序?", "安全提示",
			                System.Windows.Forms.MessageBoxButtons.YesNo,
			                System.Windows.Forms.MessageBoxIcon.Warning)
			        == System.Windows.Forms.DialogResult.Yes)
			    {
			        notifyIcon1.Visible = false;   //设置图标不可见
			        this.Dispose();                //释放资源
			        Application.Exit();            //关闭应用程序窗体
			    }
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
	}
	public static class Define
	{
		public static string Htmltext = @"data\htmltext.txt";
	}
}
