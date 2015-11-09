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

    public async Task<long> GetPageSize(CancellationToken cToken)
    {
      return 42;

      System.Net.Http.HttpClient wc = new HttpClient();
      Stopwatch sw = Stopwatch.StartNew();
      byte[] apressData = await wc.GetByteArrayAsync(TargetUrl);
      Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
      return apressData.Length;
    }

    public Task PostUrl(string newUrl, CancellationToken cToken)
    {
      TargetUrl = newUrl;
      return Task.FromResult<object>(null);
    }
  }
}
