using System;
using System.Collections.Generic;
using System.Linq;

namespace UserAdminitration.Components.Web
{
	public interface IResponse 
	{
		int CodeError { get; set; }
		string MessageError { get; set; }
		bool HasError { get; set; }
	}
	
	// Remark : Should use IActionResult as interface too

	public class HttpResponse : IResponse 
	{
		public int CodeError { get; set; }
		public string MessageError { get; set; }
		public bool HasError { get; set; }
	}

	public class HttpResponse<T> : IResponse 
	{
		public int CodeError { get;set; }
		public string MessageError { get;set; }
		public bool HasError { get; set; }

		public T Data { get; private set; }
		
		
		public HttpResponse<T> SetData( T data )
		{
			Data = data;
			return this;
		}
	}

	public class HttpResponseList<T> : IResponse 
	{
		public int CodeError { get; set; }
		public string MessageError { get;set; }
		public bool HasError { get; set; }

		public IEnumerable<T> Data { get; private set; }
		
		public HttpResponseList() {
			Data = new List<T>();
		}
		
		public HttpResponseList<T> SetListData( IEnumerable<T> data )
		{
			this.Data = data;
			return this;
		}
		
	}
	
	
}