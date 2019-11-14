using System;

namespace TechTalk.GraphQl.Store.Models
{
    public interface IIdentifier
    {
        Guid Id { get; }
    }
}