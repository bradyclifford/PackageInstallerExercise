using PackageInstallerExercise.Interfaces;
using PackageInstallerExercise.Packages.Interfaces;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using PackageInstallerExercise.Packages.Exceptions;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Container for holding the mapping between package dependencies
  /// </summary>
  public class PackagesDependencyMap<P> : IDependencyMap
    where P : IPackage, new() {

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
    public IPackage AddPackage(string packageName, string dependencyName = null) {

      IPackage dependency = default(P);

      if (string.IsNullOrWhiteSpace(packageName)) {
        throw new ArgumentException("Package name cannot be empty.");
      }

      // See if package already exists in the list
      var existingPackage = this.Packages.Find(
        p => p.Name.Equals(
          packageName,
          StringComparison.CurrentCultureIgnoreCase
        ));

      // If package already has a dependency, throw duplicate error
      if (existingPackage != null && existingPackage.Dependency != null) {
        throw new PackageDuplicateException(existingPackage);
      }

      // When dependencyName is passed, find it or create it
      if (!string.IsNullOrWhiteSpace(dependencyName)) {

        // See if dependency already exists in the list
        dependency = this.Packages.Find(p => p.Name == dependencyName);

        // If dependency package doesn't already exist, create a new instance
        if (dependency == null) {
          
          dependency = new P() {
            Name = dependencyName
          };

          // Add to package list so can be found again
          this.Packages.Add(dependency);

        }

      }

      IPackage package;

      // Create new package when not found
      if (existingPackage == null) {
        package = new P() {
          Name = packageName
        };
      }
      else { // Use existing package
        package = existingPackage;
      }

      package.Dependency = dependency;

      // Determine if it contains a cycle
      if (PackageHasCycle(package, package.Name)) {
        throw new PackageContainsCycleException(package);
      }

      // Add new package to the list of packages
      if (existingPackage == null) {
        this.Packages.Add(package);
      }

      return this.Packages.Last();

    }

    /// <summary>
    /// Generates a dependency map
    /// </summary>
    /// <returns>Array of dependency names</returns>
    public string[] GetMap() {

      var map = new List<string>();
     
      foreach (var package in this.Packages) {
        GetPackageDependencies(package, map);
      }

      return map.ToArray();

    }

    /// <summary>
    /// Recursively adds each dependency name in its correct order in the tree.
    /// </summary>
    /// <param name="package">Package</param>
    /// <param name="map">Map List</param>
    private void GetPackageDependencies(IPackage package, IList map) {

      // Recurse through tree if dependency exists
      if (package.Dependency != null) {
        GetPackageDependencies(package.Dependency, map);
      }

      // Don't add if package is already in map list
      if (map.Contains(package.Name)) {
        return;
      }

      // Add the package Name to the list.
      map.Add(package.Name);

    }

    /// <summary>
    /// Determines if the package has a a cycle through recursion
    /// </summary>
    /// <param name="package">Package to check</param>
    /// <param name="originalPackageName">Original Package Name</param>
    /// <returns></returns>
    private bool PackageHasCycle(IPackage package, string originalPackageName) {

      // When dependency is null, can't be a cycle
      if (package.Dependency == null) {
        return false;
      }

      // When package and its dependency have the same name, its a cycle
      if (package.Equals(package.Dependency)) {
        return true;
      }

      // When dependency Name is the same as the original package name, its a cycle
      if (package.Dependency.Name == originalPackageName) {
        return true;
      }

      // Recurse through the dependency tree
      return PackageHasCycle(package.Dependency, originalPackageName);

    }

  }

}
