﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageInstallerExercise;
using PackageInstallerExercise.Packages;
using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class PackagesDependencyMapTests {

    private PackagesDependencyMap<PackageMock> dependencyMap;

    [TestInitialize()]
    public void Initialize() {
      dependencyMap = new PackagesDependencyMap<PackageMock>();
    }

    [TestMethod]
    [Description("Should add a package to the dependency map.")]
    public void TestAddPackageToDependencyMap() {

      // Arrange
      string packageName = "KittenService",
             dependencyName = "CamelCaser";

      var expectedPackage = new PackageMock() {
        Name = packageName,
        Dependency = new PackageMock() {
          Name = dependencyName
        }
      };

      // Act
      var actualPackage = dependencyMap.Add(packageName, dependencyName);

      // Assert
      Assert.AreEqual(expectedPackage, actualPackage);

    }

    [TestMethod]
    [Description("Should add a package and link its dependency to an existing pacakge.")]
    public void TestAddPackageToDependencyMapAndLink() {

      // Arrange
      string packageName = "KittenService",
             dependencyName = "CamelCaser";

      var expectedPackage = new PackageMock() {
        Name = packageName,
        Dependency = new PackageMock() {
          Name = dependencyName
        }
      };

      dependencyMap.Add(dependencyName); // Add package dependency first

      // Act
      var actualPackage = dependencyMap.Add(packageName, dependencyName);

      // Assert
      Assert.AreEqual(expectedPackage, actualPackage);

    }

    public class PackageMock : IPackage {

      public string Name { get; set; }
      public IPackage Dependency { get; set; }

      public override bool Equals(object obj) {

        // If parameter is null return false.
        if (obj == null) {
          return false;
        }

        // If parameter cannot be cast to Point return false.
        PackageMock p = obj as PackageMock;
        if ((System.Object)p == null) {
          return false;
        }

        // Return true if the fields match:
        return (Name == p.Name) && 
          (Dependency == null && p.Dependency == null || (Dependency.Equals(p.Dependency)));

      }

    }

  }

}
