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
      var package = this.Packages.Find(p => p.Name == packageName);

      // If package doesn't already exist, create a new instance
      if (package == null) {
        package = new P() {
          Name = packageName
        };
      }

      // When dependencyName is passed, find it or create it
      if (!string.IsNullOrEmpty(dependencyName)) {

        // See if dependency already exists in the list
        dependency = this.Packages.Find(p => p.Name == dependencyName);

        // If dependency package doesn't already exist, create a new instance
        if (dependency == null) {
          dependency = new P() {
            Name = dependencyName
          };

          // TODO: will need to remove this so the printed order is correct
          this.Packages.Add(dependency);
        }

      }

      package.Dependency = dependency;

      if (isCycle(package, package.Name)) {
        // TODO: pass in the package so it can be displayed
        throw new PackageContainsCycleException();
      }

      // Add new package to the list of packages
      this.Packages.Add(package);
      return this.Packages.Last();

    }

    public string[] GetArray() {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if the package has a a cycle through recursion
    /// </summary>
    /// <param name="package">Package to check</param>
    /// <param name="originalPackageName">Original Package Name</param>
    /// <returns></returns>
    private bool isCycle(IPackage package, string originalPackageName) {

      // When dependency is null, can't be a cycle
      if (package.Dependency == null) {
        return false;
      }

      // TODO: move this out into Add method? 
      // TODO: compare package objects instead?
      // When package and its dependency have the same name, its a cycle
      if (package.Name == package.Dependency.Name) {
        return true;
      }

      // When dependency Name is the same as the orginal package name, its a cycle
      if (package.Dependency.Name == originalPackageName) {
        return true;
      }

      // Recurse through the dependency tree
      return isCycle(package.Dependency, originalPackageName);

    }

  }

}
