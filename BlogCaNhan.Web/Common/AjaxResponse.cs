using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCaNhan.Web.Common
{
    public class AjaxResponse
    {
        public AjaxResponse(bool success = false, string statusText = "", int statusCode = 505)
        {
            this.success = success;
            this.statusText = statusText;
            this.statusCode = statusCode;
        }

        public bool? success { get; set; }
        public string statusText { get; set; }
        public int? statusCode { get; set; }
    }
}
