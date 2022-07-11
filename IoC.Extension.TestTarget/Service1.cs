using IoC.Extensions;

namespace IoC.Extenstion.TestTarget;

[IoCExport(typeof(IService1), InstanceLifeTime.Scoped)]
public class Service1 : IService1
{
    public bool GetBool()
    {
        return true;
    }
}