namespace Abat.URLShortener.Core.Interfaces
{
	public interface IUrlIdentifierService
	{
		Task<string> GenerateUrlIdentifier();
	}
}
