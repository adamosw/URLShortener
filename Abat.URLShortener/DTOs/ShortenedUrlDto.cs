
using Abat.URLShortener.Core.Entities;

namespace Abat.URLShortener.DTOs
{
	public class ShortenedUrlDto
	{
		public string ShortUrlIdentifier { get; set; }
		public string TargetUrl { get; set; }
		public DateTime ExpirationDate { get; set; }

		public ShortenedUrl MapToEntity()
		{
			return new ShortenedUrl(ShortUrlIdentifier, TargetUrl, ExpirationDate);
		}
	}
}
