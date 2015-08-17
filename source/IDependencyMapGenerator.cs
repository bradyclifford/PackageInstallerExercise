using System.Collections;
namespace PackageInstallerExercise {
  public interface IDependencyMapGenerator {
    string[] CreateMap(string[] definitions);
  }
}
