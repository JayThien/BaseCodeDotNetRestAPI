using AspNetCore.Domain;
using System;

namespace ApplicationDomain.Entities
{
    public abstract class EntityBase<TKeyType> : IVersionedEntity<TKeyType>, IEntity<TKeyType>
    {

        public TKeyType Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }     // use to query/join

        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; } // use to query/join

        public byte[] RowVersion { get; set; }
    }
}
