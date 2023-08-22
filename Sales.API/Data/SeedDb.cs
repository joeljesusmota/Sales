using Sales.Shared;

namespace Sales.API.Data
{
	public class SeedDb
	{
		private readonly DataContext _context;
		public SeedDb(DataContext context)
		{
			this._context = context;
		}

		public async Task SeedAsync()
		{
			await _context.Database.EnsureCreatedAsync();
			await CheckCountriesAsync();
		}

		private async Task CheckCountriesAsync()
		{
			if (!_context.Countries.Any())
			{
				_context.Countries.Add(new Country { Name = "Colombia" });
				_context.Countries.Add(new Country { Name = "Rep. Dom." });
				_context.Countries.Add(new Country { Name = "Usa" });
				await _context.SaveChangesAsync();
			}
		}
	}
}
