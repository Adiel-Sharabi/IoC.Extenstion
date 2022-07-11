namespace IoC.Extensions;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class IoCExportAttribute : Attribute
{
    public IoCExportAttribute(Type? contractType, InstanceLifeTime lifetTime = InstanceLifeTime.Transiant)
    {
        ContractType = contractType;
        LifeTime = lifetTime;
    }

    public IoCExportAttribute()
    {
    }

    public InstanceLifeTime? LifeTime { get; set; }
    public Type? ContractType { get; set; }
}