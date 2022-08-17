using System.Text.Json;
using System.Text.Json.Nodes;
using System;
using System.IO;
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


  CreateJsonObject();
 // CreateJsonObjectWithKeyPair();
 // CreateJsonObjectFromJsonString();
 // CreateJsonArrayTest();

void CreateJsonObjectFromJsonString()
{
    JsonNode jsonNode = JsonNode.Parse(@"{""array"":[
        {""Name"": ""sakthivel"", ""age"": 34 },
        {""Name"": ""suresh"", ""age"": 34 },
        {""Name"": ""sam"", ""age"": 34 }
   ]
    }");
    Console.WriteLine(jsonNode);
}



void CreateJsonObject()
{
    var jsonsample = new JsonObject {
        ["Age"] = 29,
        ["Country"] = "India"
    };
    jsonsample["Employee"] = new JsonObject();
    jsonsample["Employee"]["Skills"] = "C#";

    Console.WriteLine(jsonsample);

}

void CreateJsonObjectWithKeyPair()
{
    KeyValuePair<string,JsonNode?>[] k = new KeyValuePair<string,JsonNode?>[]
    {
        new KeyValuePair<string,JsonNode?>( "test",123)
    };
     var jO = new JsonObject(k);
    Console.WriteLine(jO);
}
  
    
 void CreateJsonArrayTest()
 {
        JsonArray weekDiet = new JsonArray();
        for(int i=0;i<7;i++)
        {
           var j = CreateJson( i);
            weekDiet.Add(j);
        }

        for (int i=0;i<7;i++)
        {
            if (i % 2 == 1)
            {
                weekDiet[i]["RandomNumber"] = 3;
                weekDiet[i]["RandomNumber"]  = 3 * 2;
            }
        }

     Console.WriteLine(weekDiet);
 }


    JsonObject CreateJson(int i)
    {
            JsonObject diet = new JsonObject();
            diet["DayNumber"] = i;
            diet["Breakfast"] = "Banana"+ i;
            diet["Lunch"] = "Banana"+ i;
            diet["Dinner"] = "Banana"+ i;
            diet["WithSugar"] = (i % 2 == 0);
            diet["RandomNumber"] = Random.Shared.Next( 0,100);
    
        return diet;
    }