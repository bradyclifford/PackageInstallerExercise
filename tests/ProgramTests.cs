using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class ProgramTests {

    [TestMethod]
    public void TestMainOutput() {

      // Arrange
      string[] input = { "KittenService: CamelCaser, CamelCaser:" };
      var expectedOutput = "CamelCaser, KittenService";

      var writer = new ConsoleOutputWriterMock();
      var program = new Program(writer);

      // Act
      program.Run(input);

      // Assert
      Assert.AreEqual(expectedOutput, writer.GetLastLine());

    }

  }

  /// <summary>
  /// Stub ConsoleOutputWriter for mocking anything written to the screen
  /// </summary>
  public class ConsoleOutputWriterMock : IOutputWriter {

    private List<string> _writtenLines = new List<string>();

    public void WriteLine(string s) {
      _writtenLines.Add(s);
    }

    public string GetLastLine() {
      return _writtenLines.Last();
    }

    public void Flush() {
      _writtenLines = new List<string>();
    }

  }

}
