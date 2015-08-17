using PackageInstallerExercise.Packages.Interfaces;

namespace PackageInstallerExercise.Packages {

  /// <summary>
  /// Package
  /// </summary>
  public class Package: IPackage {

    public string Name { get; set; }
    public IPackage Dependency { get; set; }

    public override string ToString() {

      string value = this.Name;

      if (this.Dependency != null) {
        value += ":" + this.Dependency.Name;
      }

      return value;
    }

  }

}
