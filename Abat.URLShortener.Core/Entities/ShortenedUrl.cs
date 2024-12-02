﻿using Abat.URLShortener.Core.Extensions;

namespace Abat.URLShortener.Core.Entities
{
    public class ShortenedUrl
    {
        public int Id { get; set; }
        public string ShortUrlIdentifier { get; set; }
        public string TargetUrl { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ShortenedUrl(string shortUrlIdentifier, string targetUrl, DateTime expirationDate)
        {
			if (!targetUrl.IsUrl())
				throw new ArgumentException("Invalid URL format.");

			ShortUrlIdentifier = shortUrlIdentifier;
			TargetUrl = targetUrl;
            ExpirationDate = expirationDate;
        }

        public bool IsExpired()
        {
            return DateTime.UtcNow >= ExpirationDate;
        }
    }
}
