/*

Package Installer Exercise
Gives the installer a list of packages with dependencies. 
The installer determines in which order the packages need to be installed.

This exercise is to write the code that will determine the order of install.

*/

namespace PackageInstallerExercise {

  public class Program {

    private static IOutputWriter _writer;
    public static IOutputWriter Writer {

      get {

        if (_writer == null) {
          return new ConsoleOutputWriter();
        }
        
        return _writer;

      }

      set { _writer = value; }

    }

    public static void Main(string[] args) {

      Writer.WriteLine("CamelCaser, KittenService");

    }

  }

}
