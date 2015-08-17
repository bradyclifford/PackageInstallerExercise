using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Package
  /// </summary>
  public class Package: IPackage {

    public string Name { get; set; }
    public IPackage Dependency { get; set; }

  }

}
