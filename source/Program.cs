/*

Package Installer Exercise
Gives the installer a list of packages with dependencies. 
The installer determines in which order the packages need to be installed.

This exercise is to write the code that will determine the order of install.

*/

namespace PackageInstallerExercise {

  /// <summary>
  /// Program to execute at run
  /// </summary>
  public class Program {

    // Interface used to output results
    private IOutputWriter _writer;

    public Program(IOutputWriter writer) {
      _writer = writer;
    }

    public static int Main(string[] args) {
      var program = new Program(new ConsoleOutputWriter());
      return (int)program.Run(args);
    }

    /// <summary>
    /// Execute the program
    /// </summary>
    /// <param name="args">Array of Arguments</param>
    public ConsoleReturnTypes Run(string[] args) {
      WriteLine("CamelCaser, KittenService");
      return ConsumeArguments(args);
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

      return ConsoleReturnTypes.Success;

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
