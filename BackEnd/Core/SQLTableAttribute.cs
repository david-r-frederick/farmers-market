﻿namespace Core;

[AttributeUsage(AttributeTargets.Class)]
public class SQLTableAttribute : Attribute
{
    public string Schema { get; }
    public string TableName { get; }

    public SQLTableAttribute(string schema, string tableName)
    {
        Schema = schema;
        TableName = tableName;
    }
}