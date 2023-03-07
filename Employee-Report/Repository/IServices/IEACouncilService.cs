﻿using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEACouncilService
    {
        Task<Response> GetBenchEntry();
        Task<Response> CreateBenchEntry(EACouncilEntryExit EACouncilEntryExit);
    }
}
