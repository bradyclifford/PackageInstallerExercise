using PackageInstallerExercise.Packages.Interfaces;
using System;

namespace PackageInstallerExercise.Packages.Exceptions {
  
  /// <summary>
  /// Package Contains Cycle Exception
  /// </summary>
  public class PackageContainsCycleException : Exception {

    public IPackage Package { get; private set; }

    public PackageContainsCycleException(IPackage package) {
      this.Package = package;
    }

    public override string Message {
      get {
        return string.Format(
          "Package Contains Cycle Exception [{0}]", this.Package.ToString()
          );
      }
    }

  }

}
