using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageInstallerExercise.Packages;
using System;

namespace PackageInstallerExercise.Test.Packages {

  [TestClass]
  public class PackageTests {

    [TestMethod]
    [Description("Should return a PackageName:DependencyName string.")]
    public void TestToStringWithDependency() {

      // Arrange
      string packageName = "A",
          dependencyName = "B";

      var package = new Package() {
        Name = packageName,
        Dependency = new Package() {
          Name = dependencyName
        }
      };

      // Assert
      var actual = package.ToString();

      // Assert
      Assert.AreEqual(actual, packageName + ":" + dependencyName);

    }

  }

}
