using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
	public class ErrorDetail
	{
        public string? Message { get; set; }
        public int StatusCode { get; set; }

       
        public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}

	public class ValidationFailureErrors : ErrorDetail
	{
		public IEnumerable<ValidationFailure> Errors { get; set; }
	}
}
