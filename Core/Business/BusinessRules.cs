using Core.Utilities.Results;

namespace Core.Business
{
    public static class BusinessRules
    {
        public static IDataResult<object> Run(params IDataResult<object>[] results)
        {
            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return result;
                }
            }
            return null;
        }
        public static IResult Run(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
