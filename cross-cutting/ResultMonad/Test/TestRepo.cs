using System;

namespace ResultMonad {

    public class TestRepo
    {

        public static Result<SampleDtoClass1> GetData1(int i)
        {
        
           if (i == 0)
           {
             return new Result<SampleDtoClass1>( new ErrorItem( "error has occurred"));
           }
        
           var result = new SampleDtoClass1($"sample1{i}");
           return new Result<SampleDtoClass1>(result);
        }

        public static Result<SampleDtoClass2> GetData2(int i)
        {
           if (i == 0)
             return new Result<SampleDtoClass2>( new ErrorItem( "error has occurred"));
           
           var result = new SampleDtoClass2($"sample1{i}");
           return new Result<SampleDtoClass2>(result);
        }

    }

    public class SampleDomain
    {

        public static void Sample1( SampleDtoClass1 cls)
        {
            if ( cls.Data == "D1")
            {
                //some workflow
            }
            else 
            {
                //some workflow
            }
        }

    }
}