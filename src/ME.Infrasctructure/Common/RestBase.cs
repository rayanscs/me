using Flurl;
using Flurl.Http;
using ME.Domain.Interface;
using ME.Domain.Model.Http;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ME.Infrasctructure.Common
{
    public abstract class RestBase
    {
        private readonly IResponse _response;

        protected string BaseUrl { get; set; }
        public virtual string GetByParameterUri { get; set; }
        public virtual string GetAllUri { get; set; }
        public virtual string PostUri { get; set; }
        public virtual string UpdateUri { get; set; }

        protected RestBase(string urlbase)
        {
            BaseUrl = urlbase;
        }

        public async Task<IResponse> GetByParameter(object param, string paramName = "id")
        {
            var _repsonse = new Response();
            try
            {
                var result = await BaseUrl.AppendPathSegment(GetByParameterUri)
                    .SetQueryParam(paramName, param.ToString())
                    .AllowHttpStatus("422")
                    .GetJsonAsync<IResponse>();

                _response.SetData(result);
            }

            catch (FlurlHttpException ex)
            {
                _response.AddNotification(new Notification("422", MethodBase.GetCurrentMethod().Name, ex.GetResponseStringAsync().Result));
            }
            catch (Exception ex)
            {
                _response.AddNotification(new Notification("", MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return _response;
        }
        public async Task<IResponse> GetAll()
        {
            try
            {
                var result = await BaseUrl.AppendPathSegment(GetAllUri)
                    .AllowHttpStatus("422")
                    .GetJsonAsync<IResponse>();

                _response.SetData(result);
            }
            catch (FlurlHttpException ex)
            {
                _response.AddNotification(new Notification("422", MethodBase.GetCurrentMethod().Name, ex.GetResponseStringAsync().Result));
            }
            catch (Exception ex)
            {
                _response.AddNotification(new Notification("", MethodBase.GetCurrentMethod().Name, ex.Message));
                //.Erro($"{MethodBase.GetCurrentMethod().Name} - {ex.Message.ToString()}");
            }
            return _response;
        }
        public async Task<IResponse> Post(object obj, string cpf)
        {
            try
            {
                var result = await BaseUrl.AppendPathSegment(PostUri)
                    .WithHeader("cpf", cpf)
                    .AllowHttpStatus("422")
                    .PostJsonAsync(obj);

                var objResult = result.ResponseMessage.Content.ReadAsStringAsync().Result;
                _response.SetData(objResult);
            }
            catch (FlurlHttpException ex)
            {
                _response.AddNotification(new Notification("422", MethodBase.GetCurrentMethod().Name, ex.GetResponseStringAsync().Result));
            }
            catch (Exception ex)
            {
                _response.AddNotification(new Notification("", MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return _response;
        }
        public async Task<IResponse> Update(object obj)
        {
            try
            {
                var result = await BaseUrl.AppendPathSegment(UpdateUri)
                    .AllowHttpStatus("422")
                    .PutJsonAsync(obj);

                _response.SetData(result);
            }
            catch (FlurlHttpException ex)
            {
                _response.AddNotification(new Notification("422", "", ex.GetResponseStringAsync().Result));
            }
            catch (Exception ex)
            {
                _response.AddNotification(new Notification("", MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return _response;
        }
    }
}
