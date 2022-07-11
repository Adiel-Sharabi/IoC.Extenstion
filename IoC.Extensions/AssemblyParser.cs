using System.Reflection;
using IoC.Extensions;

namespace IoC.Extensions;

public static class AssemblyParser
{
    public static IEnumerable<ImportInfo> ParseAssembly(Assembly assembly)
    {
        var res = new List<ImportInfo>();
        var types = assembly.GetTypes().Where(d => d.GetCustomAttributes<IoCExportAttribute>().Any());
        foreach (var t in types)
        {
            var att = t.GetCustomAttributes<IoCExportAttribute>();
            foreach (var icCExportAttribute in att)
            {
                var importInfo = CreateImportInfo(icCExportAttribute, t);
                res.Add(importInfo);
            }
        }

        return res.Distinct(ImportInfo.ContractTypeImplementTypeComparer);
    }

    public static IEnumerable<ImportInfo> ParseFolder(string folder, Func<string, bool>? filter)
    {
        if (!Directory.Exists(folder)) throw new DirectoryNotFoundException(folder);

        var files = Directory.GetFiles(folder).Where(d => d.EndsWith(".dll"));
        if (filter != null)
        {
            files = files.Where(s => filter(Path.GetFileName(s)));
        }
        var res = new List<ImportInfo>();
        foreach (var file in files)
        {
            var assembly = Assembly.LoadFile(file);
            res.AddRange(ParseAssembly(assembly));
        }

        return res.Distinct(ImportInfo.ContractTypeImplementTypeComparer);
    }
    
    private static ImportInfo CreateImportInfo(IoCExportAttribute ioCExportAttribute, Type t)
    {
        var contract = ioCExportAttribute.ContractType ?? t;
        var implementation = t;
        var lifetime = ioCExportAttribute.LifeTime ?? InstanceLifeTime.Scoped;
        var res = new ImportInfo(contract, implementation, lifetime);
        return res;
    }
}