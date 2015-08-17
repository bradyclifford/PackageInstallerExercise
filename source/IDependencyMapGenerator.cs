using System.Collections;

namespace PackageInstallerExercise {

  /// <summary>
  /// Dependency Map Generator Interface
  /// </summary>
  public interface IDependencyMapGenerator {
    string[] CreateMap(string[] definitions);
  }
}
