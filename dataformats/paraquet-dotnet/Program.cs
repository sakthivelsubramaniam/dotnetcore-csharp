
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Parquet;
using Par = Parquet.Data;
using System;
using System.Text.Json.Nodes;
using System.Text.Json;
using Sys = System.Data;


    var jresult = GetdataField()
   .Select(item => ToJson(item))
   .Aggregate( new JsonArray(), (jar,item) => { jar.Add(item); return jar; }) ;

    Console.WriteLine(jresult);

    



static Par.DataField[] GetdataField()
{
    Par.DataField[] dataFields;
    using (Stream fileStream = System.IO.File.OpenRead(@"D:\code\samples\sample1.parquet"))
    {
        using var parquetReader = new ParquetReader(fileStream);
        dataFields = parquetReader.Schema.GetDataFields();
    }
    return dataFields;
}

static Par.DataColumn[] GetDataColumns()
{
    using (Stream fileStream = System.IO.File.OpenRead(@"D:\code\samples\sample1.parquet"))
    {
        using var parquetReader = new ParquetReader(fileStream);
        //var rowGroupCount = parquetReader.RowGroupCount;
        var dataFields = parquetReader.Schema.GetDataFields();
     
        // assuming there is one rowgroup
        using ParquetRowGroupReader groupReader = parquetReader.OpenRowGroupReader(0);
        Par.DataColumn[] columns =  dataFields.Select(item => groupReader.ReadColumn(item))
            .ToArray();

        return columns;
    }
}

static Sys.DataColumn ToDataColumn(Par.DataField dataField)
{
    Sys.DataColumn dataCol = new();
    dataCol.ColumnName = dataField.Name;
    dataCol.DataType = GetClrType(dataField.DataType);
    return dataCol;
}

static System.Type GetClrType(Par.DataType type1)
{
    switch (type1)  
    {
        case Par.DataType.Int32:
            return typeof(int);
        case Par.DataType.Int64:
            return typeof(long);
        case Par.DataType.Double:
            return typeof(double);
        case Par.DataType.String:
            return typeof(string);
            default:   
            return typeof(System.Type);
    };
}

static JsonObject ToJson(Par.DataField df)
{
    var j = new JsonObject();
    j["name"] = df.Name;
    j["Type"] = GetClrType(df.DataType).Name;
    return j;
 }
