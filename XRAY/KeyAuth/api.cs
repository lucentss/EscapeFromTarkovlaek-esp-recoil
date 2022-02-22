using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000007 RID: 7
	public class api
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00004220 File Offset: 0x00002620
		public api(string name, string ownerid, string secret, string version)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000042C0 File Offset: 0x000026C0
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
				return;
			}
			if (response_structure.message == "invalidver")
			{
				this.app_data.downloadLink = response_structure.download;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000021E3 File Offset: 0x000005E3
		public static bool IsDebugRelease
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021E6 File Offset: 0x000005E6
		public void Checkinit()
		{
			if (!this.initzalized)
			{
				if (api.IsDebugRelease)
				{
					api.error("Not initialized Check if KeyAuthApp.init() does exist");
					return;
				}
				api.error("Please initialize first");
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004460 File Offset: 0x00002860
		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000045D4 File Offset: 0x000029D4
		public void login(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000472C File Offset: 0x00002B2C
		public void upgrade(string username, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000485C File Offset: 0x00002C5C
		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000499C File Offset: 0x00002D9C
		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004A80 File Offset: 0x00002E80
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004B98 File Offset: 0x00002F98
		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004CA8 File Offset: 0x000030A8
		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004D8C File Offset: 0x0000318C
		public string var(string varid)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.message;
			}
			return null;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004EAC File Offset: 0x000032AC
		public List<api.msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.messages;
			}
			return null;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004FBC File Offset: 0x000033BC
		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000050E0 File Offset: 0x000034E0
		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000051FC File Offset: 0x000035FC
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000535C File Offset: 0x0000375C
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return encryption.str_to_byte_arr(response_structure.contents);
			}
			return null;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005470 File Offset: 0x00003870
		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			api.req(nameValueCollection);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005568 File Offset: 0x00003968
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000055F0 File Offset: 0x000039F0
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005648 File Offset: 0x00003A48
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000570C File Offset: 0x00003B0C
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005770 File Offset: 0x00003B70
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000057E4 File Offset: 0x00003BE4
		public string expirydaysleft()
		{
			this.Checkinit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002216 File Offset: 0x00000616
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x0400002E RID: 46
		public string name;

		// Token: 0x0400002F RID: 47
		public string ownerid;

		// Token: 0x04000030 RID: 48
		public string secret;

		// Token: 0x04000031 RID: 49
		public string version;

		// Token: 0x04000032 RID: 50
		private string sessionid;

		// Token: 0x04000033 RID: 51
		private string enckey;

		// Token: 0x04000034 RID: 52
		private bool initzalized;

		// Token: 0x04000035 RID: 53
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x04000036 RID: 54
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x04000037 RID: 55
		public api.response_class response = new api.response_class();

		// Token: 0x04000038 RID: 56
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x02000008 RID: 8
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000043 RID: 67 RVA: 0x0000223A File Offset: 0x0000063A
			// (set) Token: 0x06000044 RID: 68 RVA: 0x00002242 File Offset: 0x00000642
			[DataMember]
			public bool success { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000045 RID: 69 RVA: 0x0000224B File Offset: 0x0000064B
			// (set) Token: 0x06000046 RID: 70 RVA: 0x00002253 File Offset: 0x00000653
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000047 RID: 71 RVA: 0x0000225C File Offset: 0x0000065C
			// (set) Token: 0x06000048 RID: 72 RVA: 0x00002264 File Offset: 0x00000664
			[DataMember]
			public string contents { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000049 RID: 73 RVA: 0x0000226D File Offset: 0x0000066D
			// (set) Token: 0x0600004A RID: 74 RVA: 0x00002275 File Offset: 0x00000675
			[DataMember]
			public string response { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x0600004B RID: 75 RVA: 0x0000227E File Offset: 0x0000067E
			// (set) Token: 0x0600004C RID: 76 RVA: 0x00002286 File Offset: 0x00000686
			[DataMember]
			public string message { get; set; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x0600004D RID: 77 RVA: 0x0000228F File Offset: 0x0000068F
			// (set) Token: 0x0600004E RID: 78 RVA: 0x00002297 File Offset: 0x00000697
			[DataMember]
			public string download { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x0600004F RID: 79 RVA: 0x000022A0 File Offset: 0x000006A0
			// (set) Token: 0x06000050 RID: 80 RVA: 0x000022A8 File Offset: 0x000006A8
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000051 RID: 81 RVA: 0x000022B1 File Offset: 0x000006B1
			// (set) Token: 0x06000052 RID: 82 RVA: 0x000022B9 File Offset: 0x000006B9
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000053 RID: 83 RVA: 0x000022C2 File Offset: 0x000006C2
			// (set) Token: 0x06000054 RID: 84 RVA: 0x000022CA File Offset: 0x000006CA
			[DataMember]
			public List<api.msg> messages { get; set; }
		}

		// Token: 0x02000009 RID: 9
		public class msg
		{
			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000056 RID: 86 RVA: 0x000022D3 File Offset: 0x000006D3
			// (set) Token: 0x06000057 RID: 87 RVA: 0x000022DB File Offset: 0x000006DB
			public string message { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000058 RID: 88 RVA: 0x000022E4 File Offset: 0x000006E4
			// (set) Token: 0x06000059 RID: 89 RVA: 0x000022EC File Offset: 0x000006EC
			public string author { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600005A RID: 90 RVA: 0x000022F5 File Offset: 0x000006F5
			// (set) Token: 0x0600005B RID: 91 RVA: 0x000022FD File Offset: 0x000006FD
			public string timestamp { get; set; }
		}

		// Token: 0x0200000A RID: 10
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x17000015 RID: 21
			// (get) Token: 0x0600005D RID: 93 RVA: 0x00002306 File Offset: 0x00000706
			// (set) Token: 0x0600005E RID: 94 RVA: 0x0000230E File Offset: 0x0000070E
			[DataMember]
			public string username { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x0600005F RID: 95 RVA: 0x00002317 File Offset: 0x00000717
			// (set) Token: 0x06000060 RID: 96 RVA: 0x0000231F File Offset: 0x0000071F
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000061 RID: 97 RVA: 0x00002328 File Offset: 0x00000728
			// (set) Token: 0x06000062 RID: 98 RVA: 0x00002330 File Offset: 0x00000730
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000063 RID: 99 RVA: 0x00002339 File Offset: 0x00000739
			// (set) Token: 0x06000064 RID: 100 RVA: 0x00002341 File Offset: 0x00000741
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000065 RID: 101 RVA: 0x0000234A File Offset: 0x0000074A
			// (set) Token: 0x06000066 RID: 102 RVA: 0x00002352 File Offset: 0x00000752
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000067 RID: 103 RVA: 0x0000235B File Offset: 0x0000075B
			// (set) Token: 0x06000068 RID: 104 RVA: 0x00002363 File Offset: 0x00000763
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000B RID: 11
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600006A RID: 106 RVA: 0x0000236C File Offset: 0x0000076C
			// (set) Token: 0x0600006B RID: 107 RVA: 0x00002374 File Offset: 0x00000774
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x0600006C RID: 108 RVA: 0x0000237D File Offset: 0x0000077D
			// (set) Token: 0x0600006D RID: 109 RVA: 0x00002385 File Offset: 0x00000785
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x0600006E RID: 110 RVA: 0x0000238E File Offset: 0x0000078E
			// (set) Token: 0x0600006F RID: 111 RVA: 0x00002396 File Offset: 0x00000796
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000070 RID: 112 RVA: 0x0000239F File Offset: 0x0000079F
			// (set) Token: 0x06000071 RID: 113 RVA: 0x000023A7 File Offset: 0x000007A7
			[DataMember]
			public string version { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000072 RID: 114 RVA: 0x000023B0 File Offset: 0x000007B0
			// (set) Token: 0x06000073 RID: 115 RVA: 0x000023B8 File Offset: 0x000007B8
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000074 RID: 116 RVA: 0x000023C1 File Offset: 0x000007C1
			// (set) Token: 0x06000075 RID: 117 RVA: 0x000023C9 File Offset: 0x000007C9
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x0200000C RID: 12
		public class app_data_class
		{
			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000077 RID: 119 RVA: 0x000023D2 File Offset: 0x000007D2
			// (set) Token: 0x06000078 RID: 120 RVA: 0x000023DA File Offset: 0x000007DA
			public string numUsers { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000079 RID: 121 RVA: 0x000023E3 File Offset: 0x000007E3
			// (set) Token: 0x0600007A RID: 122 RVA: 0x000023EB File Offset: 0x000007EB
			public string numOnlineUsers { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600007B RID: 123 RVA: 0x000023F4 File Offset: 0x000007F4
			// (set) Token: 0x0600007C RID: 124 RVA: 0x000023FC File Offset: 0x000007FC
			public string numKeys { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600007D RID: 125 RVA: 0x00002405 File Offset: 0x00000805
			// (set) Token: 0x0600007E RID: 126 RVA: 0x0000240D File Offset: 0x0000080D
			public string version { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x0600007F RID: 127 RVA: 0x00002416 File Offset: 0x00000816
			// (set) Token: 0x06000080 RID: 128 RVA: 0x0000241E File Offset: 0x0000081E
			public string customerPanelLink { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000081 RID: 129 RVA: 0x00002427 File Offset: 0x00000827
			// (set) Token: 0x06000082 RID: 130 RVA: 0x0000242F File Offset: 0x0000082F
			public string downloadLink { get; set; }
		}

		// Token: 0x0200000D RID: 13
		public class user_data_class
		{
			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000084 RID: 132 RVA: 0x00002438 File Offset: 0x00000838
			// (set) Token: 0x06000085 RID: 133 RVA: 0x00002440 File Offset: 0x00000840
			public string username { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000086 RID: 134 RVA: 0x00002449 File Offset: 0x00000849
			// (set) Token: 0x06000087 RID: 135 RVA: 0x00002451 File Offset: 0x00000851
			public string ip { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000088 RID: 136 RVA: 0x0000245A File Offset: 0x0000085A
			// (set) Token: 0x06000089 RID: 137 RVA: 0x00002462 File Offset: 0x00000862
			public string hwid { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x0600008A RID: 138 RVA: 0x0000246B File Offset: 0x0000086B
			// (set) Token: 0x0600008B RID: 139 RVA: 0x00002473 File Offset: 0x00000873
			public string createdate { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x0600008C RID: 140 RVA: 0x0000247C File Offset: 0x0000087C
			// (set) Token: 0x0600008D RID: 141 RVA: 0x00002484 File Offset: 0x00000884
			public string lastlogin { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x0600008E RID: 142 RVA: 0x0000248D File Offset: 0x0000088D
			// (set) Token: 0x0600008F RID: 143 RVA: 0x00002495 File Offset: 0x00000895
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000E RID: 14
		public class Data
		{
			// Token: 0x1700002D RID: 45
			// (get) Token: 0x06000091 RID: 145 RVA: 0x0000249E File Offset: 0x0000089E
			// (set) Token: 0x06000092 RID: 146 RVA: 0x000024A6 File Offset: 0x000008A6
			public string subscription { get; set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x06000093 RID: 147 RVA: 0x000024AF File Offset: 0x000008AF
			// (set) Token: 0x06000094 RID: 148 RVA: 0x000024B7 File Offset: 0x000008B7
			public string expiry { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x06000095 RID: 149 RVA: 0x000024C0 File Offset: 0x000008C0
			// (set) Token: 0x06000096 RID: 150 RVA: 0x000024C8 File Offset: 0x000008C8
			public string timeleft { get; set; }
		}

		// Token: 0x0200000F RID: 15
		public class response_class
		{
			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000098 RID: 152 RVA: 0x000024D1 File Offset: 0x000008D1
			// (set) Token: 0x06000099 RID: 153 RVA: 0x000024D9 File Offset: 0x000008D9
			public bool success { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x0600009A RID: 154 RVA: 0x000024E2 File Offset: 0x000008E2
			// (set) Token: 0x0600009B RID: 155 RVA: 0x000024EA File Offset: 0x000008EA
			public string message { get; set; }
		}
	}
}
