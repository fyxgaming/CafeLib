using System;
using System.Linq;

public readonly struct Range
{
    readonly Index start;
    readonly Index end;
    
    /// <summary>
    /// Filters a range of a collection
    /// </summary>
    /// <param name="start">inclusive</param>
    /// <param name="end">exclusive</param>
    public Range( Index start, Index end )
    {
        this.start = start;
        this.end = end;
    }

    public static Range StartAt( Index start )
    {
        return new Range( start, new Index( 0, true ) );
    } 

    public static Range EndAt( Index end )
    {
        return new Range( new Index( 0, false ), end ); 
    }

    public static Range All => new Range( new Index( 0, false ), new Index( 0, true ) ); 
    
    

    public int GetSlice<T>( T[] array )
    {
        throw new NotImplementedException();
    }

    public ReadOnlySpan<T> GetSlice<T>( ReadOnlySpan<T> readOnlySpan )
    {
        var length = end.GetIndex( readOnlySpan ) - start.GetIndex( readOnlySpan );

        return readOnlySpan.Slice( start.GetIndex( readOnlySpan ), length );
    }
}