﻿namespace AuctionService.Domain.Entities;

public interface IAuditable
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset DateModified { get; set; }
}