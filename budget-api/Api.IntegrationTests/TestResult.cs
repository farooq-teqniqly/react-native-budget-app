// Copyright (c) Farooq Mahmud

namespace Api.IntegrationTests
{
	using System.Net.Http;

	public class TestResult<T>
	{
		public TestResult(HttpResponseMessage response, T deserializedResponse)
		{
			this.Response = response;
			this.DeserializedResponse = deserializedResponse;
		}

		public HttpResponseMessage Response { get; }

		public T DeserializedResponse { get; }
	}
}