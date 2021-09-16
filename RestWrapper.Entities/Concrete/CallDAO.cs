using System.Collections.Generic;
using RestWrapper.Entities.Abstract;

namespace RestWrapper.Entities.Concrete
{
    public class CallDAO : BaseEntityDAO
    {
        public ICollection<RequestDAO> Requests { get; set; }
    }
}
