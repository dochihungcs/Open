﻿namespace Open.Shared.Timing;

public class ClockOptions
{
    /// <summary>
    /// Default: <see cref="DateTimeKind.Unspecified"/>
    /// </summary>
    public DateTimeKind Kind { get; set; }

    public ClockOptions()
    {
        Kind = DateTimeKind.Unspecified;
    }
}
