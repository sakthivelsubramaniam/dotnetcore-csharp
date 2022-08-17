namespace  ResultMonad;
    public class SampleDtoClass1 {
        public SampleDtoClass1(string messages)
        {
           this.Data = messages; 
        }
       public string Data { get; set; } 
    }

    public class SampleDtoClass2
    {
        public SampleDtoClass2(string message)
        {
           this.Data = message; 
        }
       public string Data { get; set; } 
    }