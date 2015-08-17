
namespace PackageInstallerExercise.Packages.Interfaces {
  public interface IPackageDependencyMap {
    void Add(string packageName, string dependencyName);
    string[] GetArray();
  }
}
