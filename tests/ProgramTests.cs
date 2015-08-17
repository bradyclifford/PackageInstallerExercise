using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageInstallerExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class ProgramTests {

    private ConsoleOutputWriterMock writer;
    private PackageDependencyMapGeneratorMock generator;
    private Program program;

    [TestInitialize()]
    public void Initialize() {
      writer = new ConsoleOutputWriterMock();
      generator = new PackageDependencyMapGeneratorMock();
      program = new Program(writer, generator);
    }

    [TestMethod]
    [Description("Should write successful output to screen.")]
    public void TestMainOutput() {

      // Arrange
      string[] input = { "KittenService: CamelCaser, CamelCaser:" };
      var expectedOutput = "CamelCaser, KittenService";

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

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.ArgumentsIncorrectFormat, result);

    }

    [TestMethod]
    [Description("Argument cannot have just a colon.")]
    public void TestMainArgumentJustColon() {

      // Arrange
      string[] input = { ":" };

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.ArgumentsIncorrectFormat, result);

    }

    [TestMethod]
    [Description("Inform User that something went wrong.")]
    public void TestRunInformUserOfFailure() {

      // Arrange
      string[] input = { "" }; // Empty String

      // Act
      var result = program.Run(input);

      // Assert
      Assert.IsTrue(writer.HasBeenCalled());

    }

    [TestMethod]
    [Description("Parse the dependency list string into an array of packages.")]
    public void TestRunParseDependencyList() {

      // Arrange
      string[] input = { "KittenService: CamelCaser, CamelCaser:" };
      string[] expected = { "KittenService: CamelCaser", "CamelCaser:" };

      // Act
      var result = program.Run(input);

      // Assert
      CollectionAssert.AreEqual(expected, generator.Definitions);

    }

    [TestMethod]
    [Description("Catches & handles an unknown error and display a safe message to the user.")]
    public void TestRunHandleUnknownError() {

      // Arrange
      string[] input = { "KittenService: CamelCaser, CamelCaser:" };
      generator.ThrowError = true;

      // Act
      var result = program.Run(input);

      // Assert
      Assert.AreEqual(ConsoleReturnTypes.UnknownFailure, result);
      Assert.IsTrue(writer.HasBeenCalled());

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

    public bool HasBeenCalled() {
      return _writtenLines.Count > 0;
    }

  }

  /// <summary>
  /// Stub PackageDependencyMapGenerator for mocking the map creation
  /// </summary>
  public class PackageDependencyMapGeneratorMock : IDependencyMapGenerator {

    public bool ThrowError { get; set; }
    public string[] Definitions { get; set; }

    public string[] CreateMap(string[] definitions) {

      if (this.ThrowError) {
        throw new Exception("Exception");
      }
      else {
        this.Definitions = definitions;
        return new string[] { "CamelCaser", "KittenService" };
      }

    }
    
  }

}