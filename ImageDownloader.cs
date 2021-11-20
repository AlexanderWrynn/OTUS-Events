using System.Net;
using System.Threading.Tasks;

namespace OTUS_Events
{
    internal class ImageDownloader : ViewModel
    {
        public async Task Download(string remoteUri, string fileName)
        {
            var myWebClient = new WebClient();
            await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
        }
    }
}
