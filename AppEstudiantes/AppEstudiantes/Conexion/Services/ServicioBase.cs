using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppEstudiantes.Conexion.Services
{
    public class ServicioBase
    {
        protected string URL = "https://192.168.1.18:45457";
        protected string ContentType = "application/json";

        protected async Task<T> HttpGet<T>(string endpoint)
        {
            T result = default(T);

            HttpClientHandler insecureHandler = GetInsecureHandler();
            HttpClient client = new HttpClient(insecureHandler);
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(ContentType));



            try
            {
                if (!endpoint.EndsWith("/"))
                {
                    endpoint += "/";
                }


                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {

                    result = await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    Error("Error HttpGet en Servicio '" + endpoint + "': " + response.StatusCode + ". " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error HttpGet en Servicio '" + endpoint + "'. " + ex.ToString());
            }

            client.Dispose();

            return result;
        }


        protected async Task<T> HttpPost<T>(string endpoint, object request)
        {
            T result = default(T);

            HttpClientHandler insecureHandler = GetInsecureHandler();
            HttpClient client = new HttpClient(insecureHandler);
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(ContentType));


            try
            {

                var myContent = JsonConvert.SerializeObject(request);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(ContentType);


                HttpResponseMessage response = await client.PostAsync(endpoint, byteContent);
                if (response.IsSuccessStatusCode)
                {

                    result = await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    Error("Error HttpPost en Servicio '" + endpoint + "': " + response.StatusCode + ". " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error HttpPost en Servicio '" + endpoint + "'. " + ex.ToString());
            }


            client.Dispose();

            return result;
        }

        //put
        protected async Task<T> HttpPut<T>(string endpoint, object request)
        {
            T result = default(T);

            HttpClientHandler insecureHandler = GetInsecureHandler();
            HttpClient client = new HttpClient(insecureHandler);
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(ContentType));


            try
            {

                var myContent = JsonConvert.SerializeObject(request);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(ContentType);


                HttpResponseMessage response = await client.PutAsync(endpoint, byteContent);
                if (response.IsSuccessStatusCode)
                {

                    result = await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    Error("Error HttpPost en Servicio '" + endpoint + "': " + response.StatusCode + ". " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error HttpPost en Servicio '" + endpoint + "'. " + ex.ToString());
            }


            client.Dispose();

            return result;
        }



        private HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }



        public event EventHandler<string> OnError;
        private void Error(string error)
        {
            EventHandler<string> handler = OnError;
            if (handler != null)
            {
                handler(this, error);
            }
        }
    }

}
