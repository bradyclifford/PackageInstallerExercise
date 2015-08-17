using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Package
  /// </summary>
  public class Package: IPackage {

    public string Name { get; set; }
    public IPackage Dependency { get; set; }

    public override bool Equals(object obj) {

      // If parameter is null return false.
      if (obj == null) {
        return false;
      }

      // If parameter cannot be cast to Package return false.
      Package p = obj as Package;
      if ((System.Object)p == null) {
        return false;
      }

      // Return true if the fields match:
      return (Name == p.Name) &&
        (Dependency == null && p.Dependency == null || (Dependency.Equals(p.Dependency)));

    }

    /// <summary>
    /// String Representation of the Package
    /// </summary>
    /// <returns>PackangeName:DependencyName</returns>
    public override string ToString() {

      string value = this.Name;

      if (this.Dependency != null) {
        value += ":" + this.Dependency.Name;
      }

      return value;
    }

  }

}
