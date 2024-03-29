﻿using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.FahrtService
{
    public interface IFahrtService
    {
        Task<ServiceResponse<Fahrt>> CreateFahrtAsync(Fahrt fahrt);
        Task<ServiceResponse<Fahrt>> GetFahrtAsync(int fahrtId);
        Task<ServiceResponse<List<Fahrt>>> GetFahrtenAsync();
        Task<ServiceResponse<Fahrt>> UpdateFahrt(Fahrt fahrt);
        Task<ServiceResponse<List<Fahrt>>> GetFahrtenByUserIdAsync(string userId);
    }
}
