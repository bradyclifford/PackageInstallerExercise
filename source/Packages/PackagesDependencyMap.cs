using PackageInstallerExercise.Interfaces;
using PackageInstallerExercise.Packages.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Container for holding the mapping between package dependencies
  /// </summary>
  public class PackagesDependencyMap<P> : IDependencyMap
    where P : IPackage, new() {

    //private _packageType;

    public List<P> Packages { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public PackagesDependencyMap() {
      this.Packages = new List<P>();
    }

    /// <summary>
    /// Add Package to dependency map.
    /// </summary>
    /// <param name="packageName">Package Name</param>
    /// <param name="dependencyName">Dependency Name</param>
    /// <remarks>When dependency already exists in map, will link instead of create</remarks>
    public void Add(string packageName, string dependencyName = null) {
      this.Packages.Add(new P() {
        Name = packageName,
        Dependency =  dependencyName
      });
    }

    public string[] GetArray() {
      throw new NotImplementedException();
    }

  }

}
