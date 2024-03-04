using Microsoft.Web.Administration;

namespace MonService
{
    public class SiteWrapper : ISiteWrapper
    {
        private Site _site;
        public SiteWrapper(Site site)
        {
            _site = site;
        }
        public ObjectState State => _site.State;

        public void Start()
        {
            _site.Start();
        }
    }
}
