// File: HikAGVService
// Author: linxmouse@gmail.com
// Creation: 2022/6/16 21:20:19
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using HikRCS.AspNetCore.Configuration;
using HikRCS.AspNetCore.Models;
using Microsoft.Extensions.Options;

namespace HikRCS.AspNetCore.Services
{
    public class HikAGVService : IHikAGVService
    {
        private readonly string _baseUrl;
        private readonly HikRCSOptions _hikRCS;

        private readonly string _createTaskRouter;
        private readonly string _continueTaskRouter;
        private readonly string _cancelTaskRouter;
        private readonly string _getTaskStatusRouter;
        private readonly string _freeAGVRouter;

        public HikAGVService(IOptions<HikRCSOptions> hikRCS)
        {
            _hikRCS = hikRCS.Value;
            _baseUrl = _hikRCS.RCSUrl;

            _createTaskRouter = _hikRCS.CreateTaskRouter;
            _continueTaskRouter = _hikRCS.ContinueTaskRouter;
            _cancelTaskRouter = _hikRCS.CancelTaskRouter;
            _getTaskStatusRouter = _hikRCS.GetTaskStatusRouter;
            _freeAGVRouter = _hikRCS.FreeAGVRouter;
        }

        public virtual async Task<(bool success, string message)> CancelTask(HikCancelTaskModel cancelTaskModel)
        {
            var apiPath = _baseUrl + _cancelTaskRouter;

            var response = await apiPath.PostJsonAsync(cancelTaskModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }

        public virtual async Task<(bool success, string message)> ContinueTask(HikContinueTaskModel continueTaskModel)
        {
            var apiPath = _baseUrl + _continueTaskRouter;

            var response = await apiPath.PostJsonAsync(continueTaskModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }

        public virtual async Task<(bool success, string message)> CreateTask(HikGenTaskModel genTaskModel)
        {
            var apiPath = _baseUrl + _continueTaskRouter;

            var response = await apiPath.PostJsonAsync(genTaskModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }

        public virtual async Task<(bool success, string message)> FreeAGV(HikFreeAGVModel freeAGVModel)
        {
            var apiPath = _baseUrl + _continueTaskRouter;

            var response = await apiPath.PostJsonAsync(freeAGVModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }

        public virtual async Task<HikTaskStatusModel> GetTaskStatus(HikGetTaskStatusModel getTaskStatusModel)
        {
            var apiPath = _baseUrl + _continueTaskRouter;

            var response = await apiPath.PostJsonAsync(getTaskStatusModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return new HikTaskStatusModel { code = "1", message = response.ResponseMessage.ReasonPhrase };
            return await response.GetJsonAsync<HikTaskStatusModel>();
        }
    }
}
