using Abat.URLShortener.Core.Interfaces;
using Abat.URLShortener.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Abat.URLShortener.Controllers
{
	[ApiController]
	public class ShortenedUrlController : ControllerBase
	{
		private readonly IShortenedUrlRepository _shortenedUrlRepository;

        public ShortenedUrlController(IShortenedUrlRepository shortenedUrlRepository)
        {
			_shortenedUrlRepository = shortenedUrlRepository;
        }

		[HttpGet]
		[Route("{shortUrlIdentifier}")]
		public async Task<ActionResult> RedirectToTargetUrl(string shortUrlIdentifier)
		{
			var foundShortenedUrl = await _shortenedUrlRepository.GetAsync(shortUrlIdentifier);
			if (foundShortenedUrl != null)
			{
				if (foundShortenedUrl.IsExpired())
				{
					await _shortenedUrlRepository.DeleteAsync(foundShortenedUrl.Id);

					return NotFound();
				}

				return Redirect(foundShortenedUrl.TargetUrl);
			}

			return NotFound();
		}

		[HttpPost]
		[Route("api/ShortenedUrl/Add")]
		public Task AddShortenedUrl(ShortenedUrlDto shortenedUrl)
		{
			return _shortenedUrlRepository.AddAsync(shortenedUrl.MapToEntity());
		}

		[HttpPost]
		[Route("api/ShortenedUrl/Delete/{id:int}")]
		public Task DeleteShortenedUrl(int id)
		{
			return _shortenedUrlRepository.DeleteAsync(id);
		}
	}
}
