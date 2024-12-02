using Abat.URLShortener.Core.Entities;

namespace Abat.URLShortener.Core.Interfaces
{
	public interface IShortenedUrlService
	{
		void Add(ShortenedUrl shortenedUrl);

		void Delete(int id);

		ShortenedUrl Get(string shortUrlIdentifier);
	}
}
