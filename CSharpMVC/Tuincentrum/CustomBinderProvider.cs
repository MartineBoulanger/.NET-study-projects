using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Tuincentrum
{
    public class CustomBinderProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //throw new NotImplementedException();
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.ModelType == typeof(decimal))
            {
                return new DecimalModelBinder();
            }
            return null;
        }
    }
}
