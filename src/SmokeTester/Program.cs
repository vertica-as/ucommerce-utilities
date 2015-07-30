using System;
using UCommerce.EntitiesV2;
using Vertica.UCommerce.Utilities.Testing.Builders;

namespace SmokeTester
{
	class Program
	{
		static void Main(string[] args)
		{
			Country country = new CountryBuilder();

			Console.WriteLine(country.Culture);
		}
	}
}
