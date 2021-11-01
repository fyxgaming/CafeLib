using System;
using System.Linq;
using CafeLib.Core.Buffers;

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

    public static Range StartAt( int start )
    {
        return StartAt( new Index( start ) );
    }

    public static Range EndAt( Index end )
    {
        return new Range( new Index( 0, false ), end ); 
    }
    public static Range EndAt( int end )
    {
        return EndAt( new Index( end ) ); 
    }

    public static Range All => new Range( new Index( 0, false ), new Index( 0, true ) ); 
    
    

    public int GetSlice<T>( T[] array )
    {
        throw new NotImplementedException();
    }

    public ReadOnlySpan<T> GetSlice<T>( ReadOnlySpan<T> readOnlySpan )
    {
        var length = end.GetIndex( readOnlySpan ) - start.GetIndex( readOnlySpan ) - 1;

        return readOnlySpan.Slice( start.GetIndex( readOnlySpan ), length );
    }
    
    public ByteMemory GetSlice( ByteMemory byteMemory )
    {
        var length = end.GetIndex( byteMemory ) - start.GetIndex( byteMemory ) - 1;

        return byteMemory.Slice( start.GetIndex( byteMemory ), length );
    }
    
    public ByteSpan GetSlice( ByteSpan byteMemory )
    {
        var length = end.GetIndex( byteMemory ) - start.GetIndex( byteMemory ) - 1;

        return byteMemory.Slice( start.GetIndex( byteMemory ), length );
    }
    
    public string GetSlice( string str )
    {
        var length = end.GetIndex( str ) - start.GetIndex( str ) - 1;

        return str.Substring( start.GetIndex( str ), length );
    }
    
    public ByteMemory GetSlice<T>( Span<T> span )
    {
        // var length = end.GetIndex( span ) - start.GetIndex( span ) - 1;
        //
        // return span.Slice( start.GetIndex( span ), length );
        throw new NotImplementedException();
    } 

}