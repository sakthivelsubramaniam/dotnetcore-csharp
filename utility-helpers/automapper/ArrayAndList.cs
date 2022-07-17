namespace Automapper
{
	
		public class ArrayAndList
		{

			public void MyMethod(string parameter)
			{

				var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

				var sources = new[]
					{
						new Source { Value = 5 },
						new Source { Value = 6 },
						new Source { Value = 7 }
					};

				IEnumerable<Destination> ienumerableDest = mapper.Map<Source[], IEnumerable<Destination>>(sources);
				ICollection<Destination> icollectionDest = mapper.Map<Source[], ICollection<Destination>>(sources);
				IList<Destination> ilistDest = mapper.Map<Source[], IList<Destination>>(sources);
				List<Destination> listDest = mapper.Map<Source[], List<Destination>>(sources);
				Destination[] arrayDest = mapper.Map<Source[], Destination[]>(sources);

			}
			

		}



public class Source
{
	public int Value { get; set; }
}

public class Destination
{
	public int Value { get; set; }
}


} // namespace