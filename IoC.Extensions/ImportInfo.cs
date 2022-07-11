namespace IoC.Extensions;

public class ImportInfo
{
    public ImportInfo(Type contractType, Type implementType, InstanceLifeTime lifeTime = InstanceLifeTime.Transiant)
    {
        ContractType = contractType;
        ImplementType = implementType;
        InstanceLifeTime = lifeTime;
    }

    public static IEqualityComparer<ImportInfo> ContractTypeImplementTypeComparer { get; } =
        new ContractTypeImplementTypeEqualityComparer();

    public Type ContractType { get; set; }
    public Type ImplementType { get; set; }
    public InstanceLifeTime InstanceLifeTime { get; set; }

    private sealed class ContractTypeImplementTypeEqualityComparer : IEqualityComparer<ImportInfo>
    {
        public bool Equals(ImportInfo? x, ImportInfo? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.ContractType == y.ContractType && x.ImplementType == y.ImplementType;
        }

        public int GetHashCode(ImportInfo obj)
        {
            return HashCode.Combine(obj.ContractType, obj.ImplementType);
        }
    }
}