using System.Net;
using System.Threading;

WebRequest req = WebRequest.Create("http://www.google.com/#q=weather");

AsyncCallback callback = delegate (IAsyncResult iar)
{
  WebResponse resp = req.EndGetResponse(iar);
  ProcessResponse(resp);
};
req.BeginGetResponse(callback, null);