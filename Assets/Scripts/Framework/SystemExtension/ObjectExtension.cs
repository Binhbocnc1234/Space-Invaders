using System;

public static class ObjectExtension 
{
    public static bool IsNullableEnum(this Type t)
    {
        Type u = Nullable.GetUnderlyingType(t);
        return (u != null) && u.IsEnum;
    }
}
