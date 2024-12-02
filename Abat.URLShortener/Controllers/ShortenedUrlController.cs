using Abat.URLShortener.Core.Entities;
using Abat.URLShortener.Core.Interfaces;
using Abat.URLShortener.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Abat.URLShortener.Controllers
{
	[ApiController]
	public class ShortenedUrlController : ControllerBase
	{
		private readonly IShortenedUrlRepository _shortenedUrlRepository;
		private readonly IUrlIdentifierService _urlIdentifierService;
		private readonly ILogger<ShortenedUrlController> _logger;


		public ShortenedUrlController(
			IShortenedUrlRepository shortenedUrlRepository,
			IUrlIdentifierService urlIdentifierService,
			ILogger<ShortenedUrlController> logger)
        {
			_shortenedUrlRepository = shortenedUrlRepository;
			_urlIdentifierService = urlIdentifierService;
			_logger = logger;
        }

		[HttpGet]
		[Route("{shortUrlIdentifier}")]
		public async Task<ActionResult> RedirectToTargetUrl(string shortUrlIdentifier)
		{
			_logger.LogInformation($"RedirectToTargetUrl invoked, shortUrlIdentifier: {shortUrlIdentifier}");

			var foundShortenedUrl = await _shortenedUrlRepository.GetAsync(shortUrlIdentifier);
			if (foundShortenedUrl != null)
			{
				if (foundShortenedUrl.IsExpired())
				{
					await _shortenedUrlRepository.DeleteAsync(foundShortenedUrl.Id);

					_logger.LogInformation($"RedirectToTargetUrl handled, url expired");

					return NotFound();
				}

				_logger.LogInformation($"RedirectToTargetUrl handled");

				return Redirect(foundShortenedUrl.TargetUrl);
			}

			_logger.LogInformation($"RedirectToTargetUrl handled, identifier not found");

			return NotFound();
		}

		[HttpPost]
		[Route("api/ShortenedUrl/Add")]
		public async Task<string> AddShortenedUrl(ShortenedUrlDto shortenedUrl)
		{
			_logger.LogInformation($"AddShortenedUrl invoked, shortenedUrl: {shortenedUrl.ToString()}");

			if (shortenedUrl.ShortUrlIdentifier == null)
			{
				shortenedUrl.ShortUrlIdentifier = await _urlIdentifierService.GenerateUrlIdentifier();
			}

			var entity = new ShortenedUrl(shortenedUrl.ShortUrlIdentifier, shortenedUrl.TargetUrl, shortenedUrl.ExpirationDate);

			await _shortenedUrlRepository.AddAsync(entity);

			_logger.LogInformation("AddShortenedUrl handled");

			return entity.ShortUrlIdentifier;
		}

		[HttpPost]
		[Route("api/ShortenedUrl/Delete/{id:int}")]
		public async Task DeleteShortenedUrl(int id)
		{
			_logger.LogInformation($"DeleteShortenedUrl invoked, id: {id}");

			await _shortenedUrlRepository.DeleteAsync(id);

			_logger.LogInformation("DeleteShortenedUrl handled");
		}
	}
}
