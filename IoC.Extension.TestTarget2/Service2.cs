using IoC.Extenstion.TestTarget;
using IoC.Extensions;

namespace IoC.Extension.TestTarget2;

[IoCExport(typeof(IService2), InstanceLifeTime.Scoped)]
public class Service2 : IService2
{
    private int i = 1;

    public int GetInt()
    {
        return i++;
    }
}