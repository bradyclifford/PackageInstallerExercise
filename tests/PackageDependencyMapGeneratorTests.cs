using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageInstallerExercise.Packages;

namespace PackageInstallerExercise.Test {

  [TestClass]
  public class PackageDependencyMapGeneratorTests {

    private PackagesDependencyMapGenerator generator;

    [TestInitialize()]
    public void Initialize() {
      generator = new PackagesDependencyMapGenerator(':');
    }

    [TestMethod]
    public void TestCreateMapReturnsDependencyMapList() {

      // Arrange
      string[] definitions = { "KittenService: CamelCaser, CamelCaser:" };
      string[] expected = { "CamelCaser", "KittenService" };

      // Act
      var dependencyMapList = generator.CreateMap(definitions);

      // Assert
      CollectionAssert.AreEqual(expected, dependencyMapList);

    }

  }

}
