using System;
using System.Collections.Generic;
using System.Text;

namespace order.core.Entities.Base
{
   public  interface IEntityBase<TId>
    {
        TId Id { get; set; }

    }
}
