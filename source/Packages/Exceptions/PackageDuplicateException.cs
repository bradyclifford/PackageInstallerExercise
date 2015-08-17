using PackageInstallerExercise.Packages.Interfaces;
using System;

namespace PackageInstallerExercise.Packages.Exceptions {

  /// <summary>
  /// Package Is a Duplicate Exception
  /// </summary>
  public class PackageDuplicateException : Exception {

    public IPackage Package { get; private set; }

    public PackageDuplicateException(IPackage package) {
      this.Package = package;
    }

    public override string Message {
      get {
        return string.Format(
          "Package Is a Duplicate [{0}]", this.Package.ToString()
          );
      }
    }

  }
}
