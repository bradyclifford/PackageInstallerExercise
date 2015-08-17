namespace PackageInstallerExercise.Interfaces {

  /// <summary>
  /// Dependency Map Interface
  /// </summary>
  public interface IDependencyMap {
    void Add(string packageName, string dependencyName);
    string[] GetArray();
  }

}
