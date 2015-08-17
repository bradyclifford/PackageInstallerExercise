using PackageInstallerExercise.Interfaces;
using System;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Package Dependency Map Generator
  /// </summary>
  public class PackagesDependencyMapGenerator : IDependencyMapGenerator {

    private char _delimiter;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="delimiter">Delimiter separating the Package from the dependency</param>
    public PackagesDependencyMapGenerator(char delimiter) {
      _delimiter = delimiter;
    }

    public string[] CreateMap(string[] definitions) {
      throw new NotImplementedException();
    }
  }
}
