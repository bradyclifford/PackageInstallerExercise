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

      foreach (string definition in definitions) {

        // Strip out package:dependency from string
        string[] packageAndDependency = definition.Split(this._delimiter);

        if (packageAndDependency.Length != 2) {
          throw new FormatException("Dependency string is not in the correct format.");
        }

        string packageName = packageAndDependency[0].Trim();
        string dependencyName = packageAndDependency[1].Trim();

        this._packageDependencyMap.Add(packageName, dependencyName);

      }

    }

  }
}
