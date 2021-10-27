using System;

public readonly struct Index
{
    readonly int value;
    readonly bool fromEnd;

    public Index( int value, bool fromEnd )
    {
        this.value = value;
        this.fromEnd = fromEnd;
    }

    int GetIndex( int length )
    {
        return fromEnd ? length - value : value;
    }

    public int GetIndex( Array array )
    {
        return GetIndex( array.Length );
    }

    public int GetIndex<T>( ReadOnlySpan<T> readOnlySpan )
    {
        return GetIndex( readOnlySpan.Length );
    }

    public int GetIndex<T>( Memory<T> memory )
    {
        return GetIndex( memory.Length );
    }
}