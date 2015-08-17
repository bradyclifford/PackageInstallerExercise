﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

      // Act
      var actual = package.ToString();

      // Assert
      Assert.AreEqual(actual, packageName + ":" + dependencyName);

    }

    [TestMethod]
    [Description("Should return a PackageName string.")]
    public void TestToStringWithoutDependency() {

      // Arrange
      string packageName = "A";

      var package = new Package() {
        Name = packageName
      };

      // Act
      var actual = package.ToString();

      // Assert
      Assert.AreEqual(actual, packageName);

    }

    [TestMethod]
    [Description("Should be equal when both packages have same name and dependency.")]
    public void TestEqualSameNameAndDependency() {

      // Arrange
      string packageName = "A",
          dependencyName = "B";

      var package1 = new Package() {
        Name = packageName,
        Dependency = new Package() {
          Name = dependencyName
        }
      };

      var package2 = new Package() {
        Name = packageName,
        Dependency = new Package() {
          Name = dependencyName
        }
      };

      // Act & Assert
      Assert.AreEqual(package1, package2);

    }

  }

}
