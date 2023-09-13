﻿using System.ComponentModel.DataAnnotations;

namespace Sales.Shared
{
	public class State
	{
		public int Id { get; set; }

		[Display(Name = "Estado/Provincia")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
		public string Name { get; set; } = null!;

		public int CountryId { get; set; }

		public Country? Country { get; set; }

		public ICollection<City> Cities { get; set; }

		public int CitiesNumber => Cities == null ? 0 : Cities.Count;
	}
}
