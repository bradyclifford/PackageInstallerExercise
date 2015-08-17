using PackageInstallerExercise.Packages.Interfaces;
using System;

namespace PackageInstallerExercise.Packages.Exceptions {

  /// <summary>
  /// Package Is a Duplicate Exception
  /// </summary>
  public class PackageDuplicateException : PackageExceptionBase {

    public PackageDuplicateException(IPackage package) 
      : base(package) { }

    public override string Name {
      get {
        return "Package already added";
      }
    }

  }
}
