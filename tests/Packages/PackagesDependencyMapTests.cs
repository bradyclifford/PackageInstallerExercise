﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageInstallerExercise;
using PackageInstallerExercise.Packages;
using PackageInstallerExercise.Packages.Exceptions;
using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class PackagesDependencyMapTests {

    private PackagesDependencyMap<PackageMock> dependencyMap;

    [TestInitialize()]
    public void Initialize() {
      dependencyMap = new PackagesDependencyMap<PackageMock>();
    }

    #region Tests

      #region AddPackage

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
        var actualPackage = dependencyMap.AddPackage(packageName, dependencyName);

        // Assert
        Assert.AreEqual(expectedPackage, actualPackage);

      }

      [TestMethod]
      [Description("Should add a package and link its dependency to an existing package.")]
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

        dependencyMap.AddPackage(dependencyName); // Add package dependency first

        // Act
        var actualPackage = dependencyMap.AddPackage(packageName, dependencyName);

        // Assert
        Assert.AreEqual(expectedPackage, actualPackage);

      }

      [TestMethod]
      [Description("Should add a package and a new dependency to the package list when it doesn't already exist.")]
      public void TestAddPackageToDependencyMapAndCreateDependencyPackage() {

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
        var actualPackage = dependencyMap.AddPackage(packageName, dependencyName);

        // Assert
        Assert.AreEqual(expectedPackage, actualPackage);

      }

        #region Contains Cycle

        [TestMethod]
        [Description("Should throw PackageContainsCycleException Error.")]
        [ExpectedException(typeof(PackageContainsCycleException))]
        public void TestAddPackageThrowContainsCycleException() {

          // Arrange
          dependencyMap.AddPackage("A", "C");
          dependencyMap.AddPackage("B", "A");

          // Act & Assert
          dependencyMap.AddPackage("C", "B");

        }

        [TestMethod]
        [Description("Should throw PackageContainsCycleException Error. Scenario from exercise.")]
        [ExpectedException(typeof(PackageContainsCycleException))]
        public void TestAddPackageThrowContainsCycleException2() {

          // Arrange
          dependencyMap.AddPackage("A");
          dependencyMap.AddPackage("B", "C");
          dependencyMap.AddPackage("C", "F");
          dependencyMap.AddPackage("D", "A");
          dependencyMap.AddPackage("E");

          // Act & Assert
          dependencyMap.AddPackage("F", "B");

        }

        [TestMethod]
        [Description("Should throw PackageContainsCycleException Error when a package and its dependency are the same.")]
        [ExpectedException(typeof(PackageContainsCycleException))]
        public void TestAddPackageThrowContainsCycleExceptionWhenSamePackageAdded() {
          // Arrange, Act & Assert
          dependencyMap.AddPackage("A", "A");
        }

        #endregion

      [TestMethod]
      [Description("Should throw PackageDuplicateException Error package has already been added.")]
      [ExpectedException(typeof(PackageDuplicateException))]
      public void TestAddPackageThrowPackageDuplicateException() {

        // Arrange
        dependencyMap.AddPackage("A", "B");

        // Act
        dependencyMap.AddPackage("a"); // Add same package but lowercase

      }

      #endregion

    [TestMethod]
    [Description("Should return a dependency map. Scenario from exercise.")]
    public void TestGetMap() {

      // Arrange
      var expected = new string[] { "A", "F", "C", "B", "D", "E" };
      
      dependencyMap.AddPackage("A");
      dependencyMap.AddPackage("B", "C");
      dependencyMap.AddPackage("C", "F");
      dependencyMap.AddPackage("D", "A");
      dependencyMap.AddPackage("E", "B");
      dependencyMap.AddPackage("F");

      // Act
      var actual = dependencyMap.GetMap();

      // Assert
      CollectionAssert.AreEqual(expected, actual);

    }

    [TestMethod]
    [Description("Should return a dependency map. Scenario 2.")]
    public void TestGetMap2() {

      // Arrange
      var expected = new string[] { "C", "A", "B" };
      dependencyMap.AddPackage("A", "C");
      dependencyMap.AddPackage("B", "C");
      dependencyMap.AddPackage("C");

      // Act
      var actual = dependencyMap.GetMap();

      // Assert
      CollectionAssert.AreEqual(expected, actual);

    }

    #endregion

    public class PackageMock : IPackage {

      public string Name { get; set; }
      public IPackage Dependency { get; set; }

      // Help out in Asserting, but also used in the actual package class.
      public override bool Equals(object obj) {

        // If parameter is null return false.
        if (obj == null) {
          return false;
        }

        // If parameter cannot be cast to PackageMock return false.
        PackageMock p = obj as PackageMock;
        if ((System.Object)p == null) {
          return false;
        }

        // Return true if the fields match:
        // TODO: do we need to match of the dependency name as well?
        return Name == p.Name;

      }

      // Help out in testing
      public override string ToString() {

        string value = this.Name;

        if (this.Dependency != null) {
          value += ":" + this.Dependency.Name;
        }

        return value;
      }

    }

  }

}
