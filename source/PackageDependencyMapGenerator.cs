﻿using PackageInstallerExercise.Interfaces;
using System;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Package Dependency Map Generator
  /// </summary>
  public class PackageDependencyMapGenerator : IDependencyMapGenerator {

    private char _delimiter;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="delimiter">Delimiter separating the Package from the dependency</param>
    public PackageDependencyMapGenerator(char delimiter) {
      _delimiter = delimiter;
    }

    public string[] CreateMap(string[] definitions) {
      throw new NotImplementedException();
    }
  }
}
