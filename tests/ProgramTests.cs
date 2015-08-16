using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class ProgramTests {

    [TestMethod]
    public void TestMainOutput() {

      // Arrange
      var input = "KittenService: CamelCaser, CamelCaser:";
      var expectedOutput = "CamelCaser, KittenService";

      // Act
      PackageInstallerExercise.Program.Main({ input });

      // Assert
      Assert.AreEqual(expectedOutput, ConsoleOutputWriterMock.GetLastLine());

    }

  }

}
