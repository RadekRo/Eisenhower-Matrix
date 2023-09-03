﻿using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Eisenhower_Matrix.Model;

public class ToDoItemDao : IToDoItemDao
{
    private readonly string? connectionString;
    public ToDoItemDao(string connectionString)
    {
        this.connectionString = connectionString;
    }
    public void Add(ToDoItem toDoItem)
    {
        const string addItemCommand = @"INSERT INTO todoitems (title, deadline, important, completed) VALUES (@title, @deadline, @important, @completed)";
        try
        {
            using var connection = new SqlConnection(connectionString);
            var cmd = new SqlCommand(addItemCommand, connection);
            cmd.Parameters.AddWithValue("@title", toDoItem.Title);
            cmd.Parameters.AddWithValue("@deadline", toDoItem.Deadline.ToString("yyyy-MM-dd"));
            int isImportantValue = toDoItem.IsImportant ? 1 : 0;
            int isDoneValue = toDoItem.IsDone ? 1 : 0;
            cmd.Parameters.AddWithValue("@important", isImportantValue);
            cmd.Parameters.AddWithValue("@completed", isDoneValue);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            cmd.ExecuteScalar();
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }
    public void Update(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }
    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
    public List<ToDoItem> GetAll()
    {
        throw new NotImplementedException();
    }

}
