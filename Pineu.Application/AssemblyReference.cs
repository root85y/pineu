using System.Reflection;

namespace Pineu.Application;

public static class AssemblyReference {
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
