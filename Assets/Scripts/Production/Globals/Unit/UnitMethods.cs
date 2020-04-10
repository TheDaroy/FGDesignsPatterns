using System.Collections.Generic;

public class UnitMethods
{
    public static IReadOnlyDictionary<int, UnitType> TypeById { get; } = new Dictionary<int, UnitType>
    {
        { 0,  UnitType.Big },
        { 1,  UnitType.Standard }
    };
    public static IReadOnlyDictionary<UnitType, int> IdByType { get; } = new Dictionary<UnitType, int>
    {
        { UnitType.Big ,  0 },
        { UnitType.Standard,  1}
    };

   
}
