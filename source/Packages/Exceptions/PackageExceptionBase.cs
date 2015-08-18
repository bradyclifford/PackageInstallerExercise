using PackageInstallerExercise.Packages.Interfaces;
using System;

namespace PackageInstallerExercise.Packages.Exceptions {

  /// <summary>
  /// Package Exception Base Class
  /// </summary>
  public abstract class PackageExceptionBase: Exception {

    // Override to provide name of the exception
    abstract public string Name { get; }

    public IPackage Package { get; private set; }

    public PackageExceptionBase(IPackage package) {
      this.Package = package;
    }

    public override string Message {
      get {
        return string.Format(
        "{0} [{1}]", this.Name, this.Package.ToString()
        );
      }
    }

  }

}