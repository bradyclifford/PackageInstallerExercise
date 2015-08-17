namespace PackageInstallerExercise.Packages.Interfaces {

  /// <summary>
  /// Package Interface
  /// </summary>
  public interface IPackage {

    string Name { get; set; }
    string Dependency { get; set; }

  }

}
