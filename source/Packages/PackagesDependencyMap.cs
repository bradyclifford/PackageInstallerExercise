using PackageInstallerExercise.Interfaces;
using PackageInstallerExercise.Packages.Interfaces;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Container for holding the mapping between package dependencies
  /// </summary>
  public class PackagesDependencyMap<P> : IDependencyMap
    where P : IPackage, new() {

    //private _packageType;

    public List<IPackage> Packages { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public PackagesDependencyMap() {
      this.Packages = new List<IPackage>();
    }

    /// <summary>
    /// Add Package to dependency map.
    /// </summary>
    /// <param name="packageName">Package Name</param>
    /// <param name="dependencyName">Dependency Name</param>
    /// <remarks>When dependency already exists in map, will link instead of create</remarks>
    public IPackage Add(string packageName, string dependencyName = null) {

      IPackage dependency = default(P);

      // When dependencyName is passed, find it or create it
      if (!string.IsNullOrEmpty(dependencyName)) {

        // See if dependency already exists in the list
        dependency = this.Packages.Find(p => p.Name == dependencyName);

        // If dependency package doesn't already exist, create a new instance
        if (dependency == null) {
          dependency = new P() {
            Name = dependencyName
          };

          // Add dependency to the Package list
          this.Packages.Add(dependency);
        }

      }

      // Add new package to the list of packages
      this.Packages.Add(new P() {
        Name = packageName,
        Dependency = dependency
      });

      return this.Packages.Last();

    }

    public string[] GetArray() {
      throw new NotImplementedException();
    }

  }

}
