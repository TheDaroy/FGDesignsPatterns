using System.Collections.Generic;

public class UnitMethods
{
    public static IReadOnlyDictionary<int, UnitType> TypeById { get; } = new Dictionary<int, UnitType>
    {
        { 0,  UnitType.Big },
        { 1,  UnitType.Standard }
    };

    public static (int,int,float) GetStats(UnitType type) // Returns int Health, int Damage, float Speed
    {
        switch (type)
        {
            case UnitType.Standard:
                return (100, 5, 10);
            case UnitType.Big:
                return (100, 15, 5);      
        }     
        return (0, 0, 0);
    }
}
