using System;

using System.Collections.Generic;
using System.Text;

namespace order.core.Entities.Base
{

    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get;   set; }

        int? _RequestHashCode;
        public bool IsTransiemt() {
            return Id.Equals(default(TId));
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is EntityBase<TId>))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType())
                return false;
            var item = (EntityBase<TId>)obj;
            if (item.IsTransiemt() || IsTransiemt())
                return false;
            else
                return item== this;

        }
        public override int GetHashCode()
        {
            if (!IsTransiemt())
            {
                if (!_RequestHashCode.HasValue)
                    _RequestHashCode = Id.GetHashCode() ^ 31;
                return _RequestHashCode.Value;
            }
            return base.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> a, EntityBase<TId> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase<TId> a, EntityBase<TId> b)
        {
            return !(a == b);
        }

    }
   
    //public override bool Equals(object obj)
    //{
    //    if (obj == null || !(obj is EntityBase<TId>))
    //        return false;

    //    if (!ReferenceEquals(this, other))
    //    {
    //        if (GetType(this) != GetUnproxiedType(other))
    //            return false;

    //        if (Id.Equals(default) || other.Id.Equals(default))
    //            return false;
    //        System.Collections.Generic.Re

    //        return Id.Equals(other.Id);
    //    }

    //    return true;
    //}
}
