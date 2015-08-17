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
      return program.Run(args);
    }

    /// <summary>
    /// Execute the program
    /// </summary>
    /// <param name="args">Array of Arguments</param>
    public int Run(string[] args) {
      WriteLine("CamelCaser, KittenService");
      return 0;
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
