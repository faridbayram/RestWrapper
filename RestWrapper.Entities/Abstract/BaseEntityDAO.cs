using System;

namespace RestWrapper.Entities.Abstract
{
    public abstract class BaseEntityDAO
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
