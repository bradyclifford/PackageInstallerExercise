using PackageInstallerExercise.Interfaces;
using PackageInstallerExercise.Packages.Interfaces;
using System;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Package Dependency Map Generator
  /// </summary>
  public class PackagesDependencyMapGenerator : IDependencyMapGenerator {

    private char _delimiter;
    private IPackageDependencyMap _packageDependencyMap;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="delimiter">Delimiter separating the Package from the dependency</param>
    public PackagesDependencyMapGenerator(char delimiter, IPackageDependencyMap packageDependencyMap = null) {
      _delimiter = delimiter;
      _packageDependencyMap = packageDependencyMap;
    }

    public string[] CreateMap(string[] definitions) {
      
      FillMap(definitions);

      return new string[] { "CamelCaser", "KittenService" };

    }

    private void FillMap(string[] definitions) {

      

    }

  }
}
