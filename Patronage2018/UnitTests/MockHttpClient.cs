﻿using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
    /*
     * Concept: https://gist.github.com/GeorgDangl/c0a85589616cf3ddffff054ee7cb585d
     */
    public class MockHttpClient
    {
        public HttpClient GetMockClient()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync((HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken) => GetMockResponse(httpRequestMessage, cancellationToken));
            return new HttpClient(mockHttpMessageHandler.Object) { BaseAddress = new Uri("http://test.com") };
        }

        private HttpResponseMessage GetMockResponse(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            if (httpRequestMessage.RequestUri.LocalPath == "/mockio")
            {
                var response = new HttpResponseMessage
                {
                    Content = new StringContent("Czary mary")
                };

                return response;
            }
            throw new NotImplementedException();
        }
    }
}
