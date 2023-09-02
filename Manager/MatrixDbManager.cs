﻿using Eisenhower_Matrix.Model;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Eisenhower_Matrix.Manager;

public class MatrixDbManager
{
   
    private string? connectionString => ConfigurationManager.AppSettings["connectionString"];
    private IToDoItemDao toDoItemDao;

    public MatrixDbManager()
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string is missing or empty.");
        }

        toDoItemDao = new ToDoItemDao(connectionString);
    }

    public void AddItem(ToDoItem toDoItem)
    {
        toDoItemDao.Add(toDoItem);
    }

    public void UpdateItem()
    {
        //ToDoItem toDoItem = toDoItemDao.Get(1); // getting an item with index 1.
        //toDoItemDao.Update(toDoItem);
    }

    public bool TestConnection()
    {
        using var connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
}