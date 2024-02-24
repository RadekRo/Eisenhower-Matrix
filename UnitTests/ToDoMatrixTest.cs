using NUnit.Framework;
using Eisenhower_Matrix;
using System;

namespace Eisenhower_Matrix.Tests 
{
	[TestFixture]
	public class ToDoMatrixTests
	{
		[Test]
		public void AddingTaskToQuarter_UpdatesQuartersListCorrectly()
		{
			// Arrange
			var matrix = new ToDoMatrix();
			int id = 1;
			string title = "Test Task";
			DateTime deadline = DateTime.Now.AddDays(5);
			bool isImportant = true;
			bool isDone = false;

			// Act
			matrix.AddItem(id, title, deadline, isImportant, isDone);
			var quarterKey = matrix.EstimateUrgency(deadline, isImportant);
			var quarter = matrix.GetQuarter(quarterKey);
			var itemsInQuarter = quarter.GetItems();

			// Assert
			Assert.IsTrue(itemsInQuarter.Exists(item => item.Id == id && item.Title == title && item.Deadline == deadline && item.IsImportant == isImportant && item.IsDone == isDone), "The task was not added correctly to the quarter's list.");
		}

        [Test]
        public void RemovingTaskFromQuarter_UpdatesQuartersListCorrectly()
        {
            // Arrange
            var matrix = new ToDoMatrix();
            string title = "Test Task";
            DateTime deadline = DateTime.Now.AddDays(5); 
            bool isDone = false;

           
            int taskId = matrix.AddItem(0, title, deadline, isImportant, isDone); 

            // Act
            matrix.GetQuarter("IU").RemoveItem(taskId); 

            // Assert
            var itemsInQuarter = matrix.GetQuarter("IU").GetItems();
            Assert.IsFalse(itemsInQuarter.Any(item => item.Id == taskId), "The task was not removed correctly from the quarter's list.");
        }
    }
}