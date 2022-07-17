// See https://aka.ms/new-console-template for more information

using System;
using ResultMonad;



var result = TestRepo.GetData1(1)
            .Bind<SampleDtoClass1>( () => TestRepo.GetData1(0))
            .Bind<SampleDtoClass2>( () => TestRepo.GetData2(3));

            /*

             ifright( same actions)
             .Bind( some action2)
             .Bind ( some action3)
             .ifLeft( some actions)
              .Bind( some actions3)

            */


Console.WriteLine("Hello, World!");
