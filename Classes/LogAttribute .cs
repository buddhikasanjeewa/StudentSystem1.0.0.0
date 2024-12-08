using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Logging;
using StudentBL.Helpers;
using System.Diagnostics;

namespace StudentSystemWebApi.Classes
{
	public class LogAttribute : Attribute, IActionFilter
	{
		
		private string message;
        //public LogAttribute(LogWriteHeper loghelper)
        //{
        //	this.loghelper = loghelper;
        //}
      
        public void OnActionExecuted(ActionExecutedContext context)
		{
		message = string.Format("Student Web Api Action Method {0} executing at {1}", context.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString());
	    LogWriteHeper.LogWrite(message);
			
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			message = string.Format("Student Web Api Action Method {0} executed at {1}", context.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString());
			LogWriteHeper.LogWrite(message);
		}
	}
}
