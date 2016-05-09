using System;
using System.Collections.Generic;
using System.Linq;
using UserAdminitration.Components.Web;

namespace UserAdminitration.Web.Manager
{
	
	public static class ServerManager
	{
		
		
		public static IResponse CreateResponseOne<T>()
		{
			return new HttpResponse<T>().None();
		}
		
		public static IResponse CreateResponseList<T>()
		{
			return new HttpResponseList<T>().None();
		}
		
		
	}
	
	
	public static class ExtensionForIResponse
	{
		// Remark ; the code was retrieved here : http://www.restapitutorial.com/httpstatuscodes.html
		
		public static IResponse Success(this IResponse resp)
		{
			resp.CodeError = 200;
			resp.MessageError = string.Empty;
			resp.HasError = false; 
			
			return resp;
		}
		
		public static IResponse FailUnknown(this IResponse resp)
		{
			resp.CodeError = 500;
			resp.MessageError = "UnKnown error, ask your administrator ...";
			resp.HasError = true; 
			
			return resp;
		}
		
		public static IResponse FailAuthorization(this IResponse resp)
		{
			resp.CodeError = 500;
			resp.MessageError = "UnKnown error, ask your administrator ...";
			resp.HasError = true; 
			
			return resp;
		}
		
		public static IResponse FailRequest(this IResponse resp)
		{
			resp.CodeError = 400;
			resp.MessageError = "Bad Request";
			resp.HasError = true;
			// TODO : Must implement it
			return resp;
		}
		
		
		public static IResponse FailFoundRessource( this IResponse resp )
		{
			resp.CodeError = 404;
			resp.MessageError = "Ressource not found";
			resp.HasError = true;
			return resp;
		}
		
		public static IResponse None(this IResponse resp) 
		{
			resp.CodeError = 501;
			resp.MessageError = "Nothing is initialized";
			resp.HasError = false;
			return resp;
		}
		
	}
	
}