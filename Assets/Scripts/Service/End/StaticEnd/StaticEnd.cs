using System;

public static class StaticEnd
{
    public static event Action<Final> ResultatEnd;
    public static void Active(Final final) { ResultatEnd?.Invoke(final); }
}