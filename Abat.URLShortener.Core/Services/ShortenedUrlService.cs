using Abat.URLShortener.Core.Entities;
using Abat.URLShortener.Core.Interfaces;

namespace Abat.URLShortener.Core.Services
{
	public class ShortenedUrlService : IShortenedUrlService
	{
		public void Add(ShortenedUrl shortenedUrl)
		{
			// Add to DB
		}

		public void Delete(int id)
		{
			// Remove from DB
		}

		public ShortenedUrl Get(string shortUrlIdentifier)
		{
			// Get from DB

			return null;
		}
	}
}
