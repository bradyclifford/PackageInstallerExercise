using PackageInstallerExercise.Interfaces;
using System;
using System.Collections;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Container for holding the mapping between package dependencies
  /// </summary>
  public class PackagesDependencyMap: IDependencyMap {

    public IList Packages { get; private set; }

    public void Add(string packageName, string dependencyName) {
      throw new NotImplementedException();
    }

    public string[] GetArray() {
      throw new NotImplementedException();
    }

  }

}
