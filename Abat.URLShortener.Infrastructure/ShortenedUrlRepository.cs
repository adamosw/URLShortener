using Abat.URLShortener.Core.Entities;
using Abat.URLShortener.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Abat.URLShortener.Infrastructure
{
	public class ShortenedUrlRepository : IShortenedUrlRepository
	{
		private readonly UrlShortenerContext _context;

		public ShortenedUrlRepository(UrlShortenerContext context)
        {
			_context = context;
        }

        public async Task<string> AddAsync(ShortenedUrl shortenedUrl)
		{
			var exisitingUrl = await _context.ShortenedUrls.SingleOrDefaultAsync(x => x.ShortUrlIdentifier == shortenedUrl.ShortUrlIdentifier);
			if (exisitingUrl != null)
			{
				throw new Exception("Url identifier already found.");
			}

			await _context.ShortenedUrls.AddAsync(shortenedUrl);
			await _context.SaveChangesAsync();

			return shortenedUrl.ShortUrlIdentifier;
		}

		public async Task DeleteAsync(int id)
		{
			var exisitingUrl = await _context.ShortenedUrls.SingleOrDefaultAsync(x => x.Id == id);
			if (exisitingUrl != null)
			{
				_context.ShortenedUrls.Remove(exisitingUrl);

				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Url not found.");
			}
		}

		public Task<ShortenedUrl?> GetAsync(string shortenedUrlIdentifier)
		{
			return _context.ShortenedUrls.SingleOrDefaultAsync(x => x.ShortUrlIdentifier == shortenedUrlIdentifier);
		}
	}
}
