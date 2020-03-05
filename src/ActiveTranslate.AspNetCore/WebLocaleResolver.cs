// Copyright (c) Daniel Crenna & Contributors. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ActiveTranslate.AspNetCore
{
	public sealed class WebLocaleResolver : ILocaleResolver
	{
		private readonly IHttpContextAccessor _accessor;

		public WebLocaleResolver(IHttpContextAccessor accessor) => _accessor = accessor;

		public IEnumerable<string> GetLanguagePreferences()
		{
			var headers = _accessor?.HttpContext?.Request?.GetTypedHeaders();
			return headers?.AcceptLanguage?.Select(x => x.Value.ToString()) ?? Enumerable.Empty<string>();
		}
	}
}