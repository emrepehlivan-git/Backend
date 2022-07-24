namespace Application.Wrappers
{
     public class PagedResponse<T> : ServiceResponse<T>
     {
          public int Page { get; set; }
          public int PageSize { get; set; }
          public int TotalCount { get; set; }

          public PagedResponse (T value) : base(value)
          {

          }


          public PagedResponse (T value, int page, int pageSize, int totalCount) : base(value)
          {
               Page = page;
               PageSize = pageSize;
               TotalCount = totalCount;
          }

          public PagedResponse (T value, int page, int pageSize, int totalCount, bool success, string message="") : base(value, success, message)
          {
               Page = page;
               PageSize = pageSize;
               TotalCount = totalCount;
          }
     }
}
