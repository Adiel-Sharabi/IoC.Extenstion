using System.Reflection;
using IoC.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddAssemblyExports(this IServiceCollection services, Assembly assembly)
    {
        var exports = AssemblyParser.ParseAssembly(assembly);
        AddToExportsToServices(services, exports);
    }

    private static void AddToExportsToServices(IServiceCollection services, IEnumerable<ImportInfo> exports)
    {
        foreach (var export in exports)
            switch (export.InstanceLifeTime)
            {
                case InstanceLifeTime.Scoped:
                    services.AddScoped(export.ContractType, export.ImplementType);
                    break;
                case InstanceLifeTime.Singleton:
                    services.AddSingleton(export.ContractType, export.ImplementType);
                    break;
                case InstanceLifeTime.Transiant:
                    services.AddTransient(export.ContractType, export.ImplementType);
                    break;
            }
    }

    public static void AddAssemblyFolderExports(this IServiceCollection services, string folder,
        Func<string, bool>? filter = null)

    {
        var exports = AssemblyParser.ParseFolder(folder, filter);
        AddToExportsToServices(services, exports);
    }
}