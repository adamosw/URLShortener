using Abat.URLShortener.Core.Entities;

namespace Abat.URLShortener.Core.Interfaces
{
	public interface IShortenedUrlRepository
	{
		Task<string> AddAsync(ShortenedUrl shortenedUrl);
		Task DeleteAsync(string shortUrlIdentifier);
		Task<ShortenedUrl?> GetAsync(string shortenedUrlIdentifier);
	}
}
