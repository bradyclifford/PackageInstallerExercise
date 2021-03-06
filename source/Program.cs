﻿/*

Package Installer Exercise
Gives the installer a list of packages with dependencies. 
The installer determines in which order the packages need to be installed.

 * Auther: Brady Clifford 
 * Date: August 15, 2015
 
Usage:
The console application accepts one command line argument. This argument will contain all the packages and their dependencies. 
Each package and its dependency is seperated by a comma wrapped by double quotes.

Usage Example:
C:\PackageInstallerExercise "KittenService: CamelCaser, CamelCaser:"

*/

using PackageInstallerExercise.Interfaces;
using PackageInstallerExercise.Packages;
using PackageInstallerExercise.Types;
using System;

namespace PackageInstallerExercise {

  /// <summary>
  /// Program to execute at runtime
  /// </summary>
  public class Program {

    // Interface used to output results
    private IOutputWriter _writer;
    private IDependencyMapGenerator _generator;
    private string[] _definitions;

    public Program(IOutputWriter writer, IDependencyMapGenerator generator) {
      // Allow for Lazy dependency injection
      _writer = writer;
      _generator = generator;
    }

    public static int Main(string[] args) {

      var dependencyMap = new PackagesDependencyMap<Package>();

      // Lazy dependency injection
      var program = new Program(
        new ConsoleOutputWriter(),
        new PackagesDependencyMapGenerator(':', dependencyMap)
      );

      return (int)program.Run(args);

    }

    /// <summary>
    /// Execute the program
    /// </summary>
    /// <param name="args">Array of Arguments</param>
    public ConsoleReturnTypes Run(string[] args) {

      ConsoleReturnTypes result;

      try {

        // Get the argument from the command line
        result = ConsumeArguments(args);

        // When we have a failure, stop and inform user
        if (result != ConsoleReturnTypes.Success) {
          HandleError(result);
          return result;
        }

        var dependencyMap = _generator.CreateMap(this._definitions);
        WriteLine(string.Join(", ", dependencyMap));

      }
      catch (Exception e) {
        result = ConsoleReturnTypes.Rejected;
        HandleError(result, e.Message);
      }

      return result;

    }

    /// <summary>
    /// Displays the failure to the user
    /// </summary>
    /// <param name="failureType"></param>
    /// <param name="details">Additional details</param>
    private void HandleError(ConsoleReturnTypes failureType, string details = null) {

      switch (failureType) {
        case ConsoleReturnTypes.NoArguments:
        case ConsoleReturnTypes.ArgumentsIncorrectFormat:
          WriteLine("Enter a list of dependencies.");
          WriteLine("Usage: \"<package>: <dependency>, ...\"");
          WriteLine("Usage Example: packageinstallerexcercise \"KittenService: CamelCaser, CamelCaser:\"");
          break;

        case ConsoleReturnTypes.TooManyArguments:
          WriteLine("Only provide one argument.");
          break;

        default:
          string line = string.Format(
            "An error occurred: {0}. \nDetails: {1}.",
            Enum.GetName(typeof(ConsoleReturnTypes), failureType),
            details
          );

          WriteLine(line);
          break;

      }

    }

    /// <summary>
    /// Parses the arguments
    /// </summary>
    /// <param name="args">Argument Array</param>
    /// <returns>0 as a success, anything greater as an error</returns>
    private ConsoleReturnTypes ConsumeArguments(string[] args) {

      // Must have only one argument
      if (args.Length == 0) {
        return ConsoleReturnTypes.NoArguments;
      }

      // Can only handle one argument
      if (args.Length > 1) {
        return ConsoleReturnTypes.TooManyArguments;
      }

      // Get the combined packages
      var packagesList = args[0];

      // Verify the argument isn't empty and contains our delimiter.
      if (string.IsNullOrEmpty(packagesList) ||
        !packagesList.Contains(":")) {
        return ConsoleReturnTypes.ArgumentsIncorrectFormat;
      }

      ParsePackagesList(packagesList);

      // Can't just have a : and no package
      if (this._definitions.Length == 1 && this._definitions[0] == ":") {
        return ConsoleReturnTypes.ArgumentsIncorrectFormat;
      }

      return ConsoleReturnTypes.Success;

    }

    /// <summary>
    /// Parse Packages List
    /// </summary>
    /// <param name="packagesList">Packages List</param>
    private void ParsePackagesList(string packagesList) {

      // Split each package:dependency
      var splitDefinitions = packagesList.Split(',');

      // Remove any trailing or leading white spaces
      for (int i = 0; i < splitDefinitions.Length; i++) {
        splitDefinitions[i] = splitDefinitions[i].Trim();
      }

      // Set the definitions for this program instance
      this._definitions = splitDefinitions;

    }

    /// <summary>
    /// Write string as a line to output
    /// </summary>
    /// <param name="s">Line to output</param>
    private void WriteLine(string s) {
      _writer.WriteLine(s);
    }

  }

}