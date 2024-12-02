namespace Abat.URLShortener.DTOs
{
	public class ShortenedUrlDto
	{
		public string? ShortUrlIdentifier { get; set; }
		public string TargetUrl { get; set; }
		public DateTime? ExpirationDate { get; set; }

		public override string ToString()
		{
			return $"ShortUrlIdentifier: {ShortUrlIdentifier}, TargetUrl: {TargetUrl}, ExpirationDate: {ExpirationDate?.ToUniversalTime()}";
		}
	}
}
