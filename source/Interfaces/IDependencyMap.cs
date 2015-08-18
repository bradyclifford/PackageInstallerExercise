using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Interfaces {

  /// <summary>
  /// Dependency Map Interface
  /// </summary>
  public interface IDependencyMap {
    IPackage AddPackage(string packageName, string dependencyName);
    string[] GetMap();
  }

}
