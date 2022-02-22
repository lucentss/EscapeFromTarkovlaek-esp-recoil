using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XRAY.Properties
{
	// Token: 0x02000003 RID: 3
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020B5 File Offset: 0x000004B5
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020BC File Offset: 0x000004BC
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020D0 File Offset: 0x000004D0
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Login
		{
			get
			{
				return (string)this["Login"];
			}
			set
			{
				this["Login"] = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020E0 File Offset: 0x000004E0
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020F4 File Offset: 0x000004F4
		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Password
		{
			get
			{
				return (string)this["Password"];
			}
			set
			{
				this["Password"] = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002104 File Offset: 0x00000504
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002118 File Offset: 0x00000518
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string Clearlog
		{
			get
			{
				return (string)this["Clearlog"];
			}
			set
			{
				this["Clearlog"] = value;
			}
		}

		// Token: 0x04000003 RID: 3
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
