using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class ProgramTests {

    [TestMethod]
    [Description("Should write successful output to screen.")]
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

    [TestMethod]
    [Description("Should fail when no argument passed.")]
    public void TestMainNoArguments() {

      // Arrange
      string[] input = { };
      var writer = new ConsoleOutputWriterMock();
      var program = new Program(writer);

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.NoArguments, result);

    }

    [TestMethod]
    [Description("Should fail when more than one argument passed.")]
    public void TestMainArgumentsMoreThanOne() {

      // Arrange
      string[] input = { "argument1", "argument2" };
      var writer = new ConsoleOutputWriterMock();
      var program = new Program(writer);

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.TooManyArguments, result);

    }

    [TestMethod]
    [Description("Should fail with no colon in argument")]
    public void TestMainArgumentNotContainColon() {

      // Arrange
      string[] input = { "argument1 with no colon" };
      var writer = new ConsoleOutputWriterMock();
      var program = new Program(writer);

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.ArgumentsIncorrectFormat, result);

    }

    [TestMethod]
    [Description("Should contain a colon.")]
    public void TestMainArgumentContainsColon() {

      // Arrange
      string[] input = { "KittenService:" };
      var writer = new ConsoleOutputWriterMock();
      var program = new Program(writer);

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.Success, result);

    }

    [TestMethod]
    [Description("Argument cannot be empty.")]
    public void TestMainArgumentEmptyString() {

      // Arrange
      string[] input = { "" }; // Empty String
      var writer = new ConsoleOutputWriterMock();
      var program = new Program(writer);

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.ArgumentsIncorrectFormat, result);

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