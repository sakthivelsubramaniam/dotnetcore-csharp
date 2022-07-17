namespace automapper
{

	public class NestedMapping
	{


		//source
		public class OuterSource
		{
			public int Value { get; set; }
			public InnerSource Inner { get; set; }
		}

		public class InnerSource
		{
			public int OtherValue { get; set; }
		}

		//destination
		public class OuterDest
		{
			public int Value { get; set; }
			public InnerDest Inner { get; set; }
		}

		public class InnerDest
		{
			public int OtherValue { get; set; }
		}

		public void MyMethod(string parameter)
		{
				var config = new MapperConfiguration(cfg => {
				cfg.CreateMap<OuterSource, OuterDest>();
				cfg.CreateMap<InnerSource, InnerDest>();
				});
				
				config.AssertConfigurationIsValid();

				var source = new OuterSource
				{
					Value = 5,
					Inner = new InnerSource {OtherValue = 15}
				};
				var mapper = config.CreateMapper();
				var dest = mapper.Map<OuterSource, OuterDest>(source);

				dest.Value.ShouldEqual(5);
				dest.Inner.ShouldNotBeNull();
				dest.Inner.OtherValue.ShouldEqual(15);

		}

		
	}
	
}