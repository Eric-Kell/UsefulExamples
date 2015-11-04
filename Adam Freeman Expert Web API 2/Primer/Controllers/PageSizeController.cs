using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Primer.Infrastructure;
using System.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Primer.Controllers
{
    [Route("api/[controller]")]
    public class PageSizeController : Controller, ICustomController
  {

    private static string TargetUrl = "http://apress.com";

    [HttpGet]
    public Task<long> GetPageSize(CancellationToken cToken)
    {
      return Task<long>.Factory.StartNew(() =>
      {
        System.Net.Http.HttpClient wc = new HttpClient();
        Stopwatch sw = Stopwatch.StartNew();
        List<long> results = new List<long>();
        for (int i = 0; i < 10; i++)
        {
          if (!cToken.IsCancellationRequested)
          {
            Debug.WriteLine("Making Request: {0}", i);
            var x = wc.GetAsync(TargetUrl);
            results.Add(i);
          }
          else
          {
            Debug.WriteLine("Cancelled");
            return 0;
          }
        }
        Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        return (long) results.Average();
      });


    }

    public Task PostUrl(string newUrl, CancellationToken cToken)
    {
      TargetUrl = newUrl;
      return Task.FromResult<object>(null);
    }

  }
}
