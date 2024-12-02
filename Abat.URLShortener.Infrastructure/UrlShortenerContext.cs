using Abat.URLShortener.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abat.URLShortener.Infrastructure
{
	public class UrlShortenerContext: DbContext
	{
		public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options)
		{
		}

		public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
	}
}
