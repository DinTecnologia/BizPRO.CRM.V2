using System;
using BizPRO.CRM.V2.Core.Interfaces;

namespace BizPRO.CRM.V2.Core.ValueObjects
{
    public class Aggregate : IAggregate
    {
        public Aggregate()
        {
            Id = Guid.NewGuid();
        }

        public Aggregate(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }
    }
}