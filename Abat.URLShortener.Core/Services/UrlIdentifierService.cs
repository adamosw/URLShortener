using Abat.URLShortener.Core.Interfaces;

namespace Abat.URLShortener.Core.Services
{
	public class UrlIdentifierService : IUrlIdentifierService
	{
		private readonly IShortenedUrlRepository _context;

		public UrlIdentifierService(IShortenedUrlRepository context)
		{
			_context = context;
		}

		public async Task<string> GenerateUrlIdentifier()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var random = new Random();
			var uniqueIdentifierFound = false;
			var newIdentifier = string.Empty;

			while (!uniqueIdentifierFound)
			{
				newIdentifier = new string(Enumerable.Repeat(chars, 8)
					.Select(s => s[random.Next(s.Length)]).ToArray());

				var foundIdentifier = await _context.GetAsync(newIdentifier);

				if (foundIdentifier == null)
				{
					uniqueIdentifierFound = true;
				}
			}

			return newIdentifier;
		}
	}
}
