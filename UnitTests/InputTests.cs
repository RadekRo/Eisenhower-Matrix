using Eisenhower_Matrix.Interfaces;
using Eisenhower_Matrix.Manager;
using Eisenhower_Matrix.View;
using Moq;
using NUnit.Framework;
using System;

namespace Eisenhower_Matrix.UnitTests
{
    [TestFixture]
    public class InputTests
    {
        [Test]
        public void GetTitle_ReturnsTitleCorrectly()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            consoleServiceMock.SetupSequence(x => x.ReadLine())
                .Returns("Test Title"); 
            var matrixDbManagerMock = new Mock<MatrixDbManager>(); 
            var input = new Input(matrixDbManagerMock.Object, consoleServiceMock.Object);

            // Act
            var title = input.GetTitle();

            // Assert
            Assert.Equals("Test Title", title);
        }
    }
}
