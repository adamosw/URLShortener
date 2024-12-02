using Abat.URLShortener.Core.Entities;
using Abat.URLShortener.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Abat.URLShortener.Controllers
{
	[ApiController]
	public class ShortenedUrlController : ControllerBase
	{
		private readonly IShortenedUrlService _shortenedUrlService;

        public ShortenedUrlController(IShortenedUrlService shortenedUrlService)
        {
			_shortenedUrlService = shortenedUrlService;
        }

		[HttpGet]
		[Route("{shortUrlIdentifier:alpha}")]
		public ActionResult RedirectToTargetUrl(string shortUrlIdentifier)
		{
			var foundShortenedUrl = _shortenedUrlService.Get(shortUrlIdentifier);
			if (foundShortenedUrl != null)
			{
				if (foundShortenedUrl.IsExpired())
				{
					_shortenedUrlService.Delete(foundShortenedUrl.Id);

					return NotFound();
				}

				return Redirect(foundShortenedUrl.TargetUrl);
			}

			return NotFound();
		}

		[HttpPost]
		[Route("api/Add")]
		public void AddShortenedUrl(ShortenedUrl shortenedUrl)
		{
			_shortenedUrlService.Add(shortenedUrl);
		}

		[HttpPost]
		[Route("api/Delete/{id:int}")]
		public void DeleteShortenedUrl(int id)
		{
			_shortenedUrlService.Delete(id);
		}
	}
}
