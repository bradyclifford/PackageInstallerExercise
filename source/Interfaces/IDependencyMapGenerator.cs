namespace PackageInstallerExercise.Interfaces {

  /// <summary>
  /// Dependency Map Generator Interface
  /// </summary>
  public interface IDependencyMapGenerator {
    string[] CreateMap(string[] definitions);
  }

}
