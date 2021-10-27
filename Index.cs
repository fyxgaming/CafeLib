
public readonly struct Index
{
    readonly int value;
    readonly bool fromEnd; 
    public Index(int value, bool fromEnd)
    {
        this.value = value;
        this.fromEnd = fromEnd;
    }
}