using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageInstallerExercise;
using PackageInstallerExercise.Packages;
using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class PackagesDependencyMapTests {

    private PackagesDependencyMap dependencyMap;

    [TestInitialize()]
    public void Initialize() {
      dependencyMap = new PackagesDependencyMap();
    }

    [TestMethod]
    [Description("Should add a package to the dependency map.")]
    public void TestAddPackageToDependencyMap() {

      // Arrange
      string packageName = "KittenService",
             dependencyName = "CamelCaser";

      var package = new PackageMock(packageName, dependencyName);

      // Act
      dependencyMap.Add(packageName, dependencyName);

      // Assert
      Assert.AreEqual(package, dependencyMap.Packages[0]);

    }

    public class PackageMock : IPackage {

      public PackageMock(string name, string dependency = "") {
        this.Name = name;
        this.Dependency = dependency;
      }

      public string Name { get; private set; }
      public string Dependency { get; private set; }

    }

  }

}
