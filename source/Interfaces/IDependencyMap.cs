using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Interfaces {

  /// <summary>
  /// Dependency Map Interface
  /// </summary>
  public interface IDependencyMap {
    IPackage Add(string packageName, string dependencyName);
    string[] GetMap();
  }

}
