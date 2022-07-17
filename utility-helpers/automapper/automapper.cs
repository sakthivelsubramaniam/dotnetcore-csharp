using System;

namespace utility
{
    public class Class1
    {

        public void MyMethod(string parameter)
        {
            var config = new MapperConfiguration(cfg => {
              

                // or  maps can be moved to profiles
                cfg.AddProfile<OrganizationProfile>();
                // or  add profile by scanning the assembly
                cfg.AddMaps(myAssembly);
                // or  by specifying Assembly as string
                cfg.AddMaps(new [] {
                    "Foo.UI",
                    "Foo.Core"
                    });
                // // Or marker types for assemblies:
                  cfg.AddMaps(new [] {
                    typeof(HomeController),
                    typeof(Entity)
                });

                // can map the source charectors to dest char
                 cfg.ReplaceMemberName("Ä", "A");

                 //prefixes and post fixes
                   cfg.ClearPrefixes();
                  cfg.RecognizePrefixes("tmp");

                  // can filter the fields
                  cfg.ShouldMapField = fi => false;

                  // can override the visitbility
                  cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                // optionally mapping can compiled immediatly instead of lazyly
                configuration.CompileMappings();

                  cfg.CreateMap<Foo, Bar>();
            });


// Or marker types for assemblies:
var configuration = new MapperConfiguration(cfg =>
  
);


            // config can be stored statically ( in Singleton Dependency container)

            var mapper = config.CreateMapper();
            // or
            var mapper = new Mapper(config);

            OrderDto dto = mapper.Map<OrderDto>(order);

        }

        public void WhenMembersNotMatch ()
        {
            // Model
            var calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };

            // Configure AutoMapper
            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<CalendarEvent, CalendarEventForm>()
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
                .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute)));

            // Perform mapping
            CalendarEventForm form = mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);

            form.EventDate.ShouldEqual(new DateTime(2008, 12, 15));
            form.EventHour.ShouldEqual(20);
            form.EventMinute.ShouldEqual(30);
            form.Title.ShouldEqual("Company Holiday Party");
        }



        public void WhenNestedMapping() 
        {
                

        }
    }

    // another approach using profiles
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Foo, FooDto>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
    
}



