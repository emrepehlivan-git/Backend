namespace Application.Wrappers
{
     public class ServiceResponse<T> : BaseResponse
     {
          public T Value { get; set; }

          public ServiceResponse (T value)
          {
               Value = value;
          }

          public ServiceResponse (T value, bool success, string message) : base(success, message)
          {
               Value = value;
          }

          public ServiceResponse (T value, bool success) : base(success)
          {
               Value = value;
          }
     }
}
