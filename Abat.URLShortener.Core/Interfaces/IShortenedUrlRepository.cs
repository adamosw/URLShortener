﻿using Abat.URLShortener.Core.Entities;

namespace Abat.URLShortener.Core.Interfaces
{
	public interface IShortenedUrlRepository
	{
		Task AddAsync(ShortenedUrl shortenedUrl);
		Task DeleteAsync(int id);
		Task<ShortenedUrl?> GetAsync(string shortenedUrlIdentifier);
	}
}
