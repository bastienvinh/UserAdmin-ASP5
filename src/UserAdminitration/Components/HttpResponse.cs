using System;
using System.Collections.Generic;
using System.Linq;

namespace UserAdminitration.Web
{
	public interface IResponse 
	{
		int CodeError { get; }
		string MessageError { get; }
		bool HasError { get; }
	}

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

		public T Data { get;set; }
	}

	public class HttpResponseList<T> : IResponse 
	{
		public int CodeError { get; set; }
		public string MessageError { get;set; }
		public bool HasError { get; set; }

		public IEnumerable<T> Data { get; private set; }
		
		public HttpResponseList(IEnumerable<T> data) {
			Data = data;
		}
		
		
	}
}