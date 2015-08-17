using PackageInstallerExercise.Interfaces;
using PackageInstallerExercise.Packages.Interfaces;
using System;
using System.Collections;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Container for holding the mapping between package dependencies
  /// </summary>
  public class PackagesDependencyMap<P> : IDependencyMap
    where P : IPackage, new() {

    //private _packageType;

    public IList Packages { get; private set; }

    public void Add(string packageName, string dependencyName) {
      var package = new P();
      package.Name = packageName;
      package.Dependency = dependencyName;
      this.Packages.Add(package);
    }

    public string[] GetArray() {
      throw new NotImplementedException();
    }

  }

}
