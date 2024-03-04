using Microsoft.Web.Administration;

namespace MonService
{
    public class SiteCollectionWrapper : ISiteCollectionWrapper
    {
        private SiteCollection _siteCollection;

        public SiteCollectionWrapper(SiteCollection siteCollection)
        {
            _siteCollection = siteCollection;
        }

        public ISiteWrapper this[string siteName] => new SiteWrapper(_siteCollection[siteName]);
    }
}
