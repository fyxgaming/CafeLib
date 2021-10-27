using System;

public readonly struct Range
{
    readonly Index start;
    readonly Index end;
    
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
}