using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Responses
{
	public class ApiResponse
	{
		public object Items { get; set; }
		public int StatusCode { get; set; }
		public string Description { get; set; }
	}
}
