using RestWrapper.Entities.Abstract;

namespace RestWrapper.Entities.Concrete
{
    public class RequestDAO : BaseEntityDAO
    {
        public int CallId { get; set; }
        public CallDAO Call { get; set; }
        public string Value { get; set; }
    }
}
