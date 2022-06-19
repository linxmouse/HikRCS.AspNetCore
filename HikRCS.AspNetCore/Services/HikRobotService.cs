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
    public class HikRobotService : IHikRobotService
    {
        private readonly string _baseUrl;
        private readonly HikRCSOptions _hikRCS;

        private readonly string _createTaskRouter;
        private readonly string _continueTaskRouter;
        private readonly string _cancelTaskRouter;
        private readonly string _getTaskStatusRouter;
        private readonly string _getRobotStatusRouter;
        private readonly string _freeRobotRouter;
        private readonly string _stopRobotRouter;
        private readonly string _resumeRobotRouter;

        public HikRobotService(IOptions<HikRCSOptions> hikRCS)
        {
            _hikRCS = hikRCS.Value;
            _baseUrl = _hikRCS.RCSUrl;

            _createTaskRouter = _hikRCS.CreateTaskRouter;
            _continueTaskRouter = _hikRCS.ContinueTaskRouter;
            _cancelTaskRouter = _hikRCS.CancelTaskRouter;
            _getTaskStatusRouter = _hikRCS.GetTaskStatusRouter;
            _getRobotStatusRouter = _hikRCS.GetRobotStatusRouter;
            _freeRobotRouter = _hikRCS.FreeRobotRouter;
            _stopRobotRouter = _hikRCS.StopRobotRouter;
            _resumeRobotRouter = _hikRCS.ResumeRobotRouter;
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

        public virtual async Task<(bool success, string message)> CreateTask(HikNewTaskModel genTaskModel)
        {
            var apiPath = _baseUrl + _continueTaskRouter;

            var response = await apiPath.PostJsonAsync(genTaskModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }

        public virtual async Task<(bool success, string message)> FreeRobot(HikFreeRobotModel freeRobotModel)
        {
            var apiPath = _baseUrl + _continueTaskRouter;

            var response = await apiPath.PostJsonAsync(freeRobotModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }

        public virtual async Task<HikRobotStatusOutModel> GetRobotStatus(HikRobotStatusInModel robotStatusInModel)
        {
            var apiPath = _baseUrl + _getRobotStatusRouter;

            var response = await apiPath.PostJsonAsync(robotStatusInModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return new HikRobotStatusOutModel { code = "1", message = response.ResponseMessage.ReasonPhrase };
            return await response.GetJsonAsync<HikRobotStatusOutModel>();
        }

        public virtual async Task<HikTaskStatusOutModel> GetTaskStatus(HikTaskStatusInModel taskStatusInModel)
        {
            var apiPath = _baseUrl + _continueTaskRouter;

            var response = await apiPath.PostJsonAsync(taskStatusInModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return new HikTaskStatusOutModel { code = "1", message = response.ResponseMessage.ReasonPhrase };
            return await response.GetJsonAsync<HikTaskStatusOutModel>();
        }

        public virtual async Task<(bool success, string message)> ResumeRobot(HikStopAndResumeRobotInModel robotInModel)
        {
            var apiPath = _baseUrl + _resumeRobotRouter;

            var response = await apiPath.PostJsonAsync(robotInModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }

        public virtual async Task<(bool success, string message)> StopRobot(HikStopAndResumeRobotInModel robotInModel)
        {
            var apiPath = _baseUrl + _stopRobotRouter;

            var response = await apiPath.PostJsonAsync(robotInModel);
            if (!response.ResponseMessage.IsSuccessStatusCode) return (false, response.ResponseMessage.ReasonPhrase);
            var result = await response.GetJsonAsync();
            if (!result.code.Equals("0")) return (false, result.message);

            return (true, result.message);
        }
    }
}
