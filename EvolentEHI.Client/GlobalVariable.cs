using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Http;

namespace EvolentEHI.Client
{
    // we can create instance of httpclient as static one time
    public  class GlobalVariable
    {
        public static HttpClient webapiclient = new HttpClient();

        
        public   GlobalVariable()
        {
            webapiclient.BaseAddress = new Uri("http://localhost:53100/api");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}