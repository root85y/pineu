using System.Reflection;

namespace Pineu.Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
