using Microsoft.AspNetCore.Http;

namespace ASPPatterns.Chap2.Service
{
	namespace ASPPatterns.Chap2.Service
	{
		public class HttpContextCacheAdapter : ICacheStorage
		{
			private IHttpContextAccessor _contextAccessor;

			public HttpContextCacheAdapter(IHttpContextAccessor contextAccessor)
			{
				_contextAccessor = contextAccessor;
			}

			public void Remove(string key)
			{
				_contextAccessor.HttpContext.Items[key] = null;
			}

			public void Store(string key, object data)
			{
				_contextAccessor.HttpContext.Items[key] = data;
			}

			public T Retrieve<T>(string key)
			{
				T itemStored = (T)_contextAccessor.HttpContext.Items[key];

				if (itemStored == null)
					itemStored = default(T);

				return itemStored;
			}
		}
	}
}