using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000011 RID: 17
	public class json_wrapper
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x0000250F File Offset: 0x0000090F
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005BD8 File Offset: 0x00003FD8
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005C30 File Offset: 0x00004030
		public object string_to_object(string json)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(json)))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000252F File Offset: 0x0000092F
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x04000062 RID: 98
		private DataContractJsonSerializer serializer;

		// Token: 0x04000063 RID: 99
		private object current_object;
	}
}
