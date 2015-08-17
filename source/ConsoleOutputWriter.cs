using PackageInstallerExercise.Interfaces;
using System;

namespace PackageInstallerExercise {

  /// <summary>
  /// Console Output Writer
  /// </summary>
  class ConsoleOutputWriter: IOutputWriter {
    public void WriteLine(string s) {
      Console.WriteLine(s);
    }
  }

}
