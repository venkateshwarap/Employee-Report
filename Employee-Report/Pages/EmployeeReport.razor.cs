using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.API.Service;
using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Repository.Services;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Employee_Report.Pages
{
    public partial class EmployeeReport
    {

         ReportService reportService=new ReportService();
        public IEnumerable<Interview>? interviewsDetails { get; set; }
        public Interview InterviewModel = new();

        public IEnumerable<Certification>? certificationslist { get; set; }
        public Certification certifications = new();

        [Inject]
        public Repository.IServices.IPowerHouseService benchServices { get; set; }
        public IEnumerable<PowerHouse> powerHouseDetails { get; set; }
        public PowerHouse powerHouseModel = new();

        public IEnumerable<EmployeePOCEntity> employeepoc { get; set; }

        public EmployeePoc employeePocModel = new();

        public IEnumerable<EmployeeProjectEntity> employee { get; set; }
        public EmployeeProject employeeProject = new();

        Repository.Services.LearningService LearningService = new();
        public IEnumerable<Learning>? learningCompleteDetails { get; set; }
        public Learning learningModel = new();

        Repository.Services.TrainingService TrainingService = new();
        public IEnumerable<Training>? trainingDetails { get; set; }
        public Training trainingModel = new();

        public IEnumerable<Poc> poc { get; set; }

        public List<ChartDataModel> pieData;
      
        public class ChartDataModel
        {
            public string Expertise { get; set; }
            public string Result { get; set; }
            public int ResultCount { get; set; }
            public int ResourceCount { get; set; }
            public string EATerm { get; set; }
            public int EAResult { get; set; }
        }
        List<ChartDataModel> ChartData = new List<ChartDataModel>
     {
         new ChartDataModel{ Expertise="Learnings",ResourceCount=10},
         new ChartDataModel{ Expertise="ProofOfConcepts",ResourceCount=8},
         new ChartDataModel{ Expertise="IPs",ResourceCount=0},
         new ChartDataModel{ Expertise="Projects",ResourceCount=80},
         new ChartDataModel{ Expertise="Trainings",ResourceCount=2},
         new ChartDataModel{  Result ="Pass",ResultCount=66},
         new ChartDataModel{ Result="Fail",ResultCount=34},
          new ChartDataModel{ EATerm="POCs",EAResult=80},
         new ChartDataModel{ EATerm="Learning",EAResult=10},
         new ChartDataModel{ EATerm="Trainings",EAResult=2},
         new ChartDataModel{ EATerm="IPs",EAResult=0}
     };
        public class PieChartDataList
        {
            public int EmployeeIdentity { get; set; }
            public string ExpertiseDoamin { get; set; }
        }

       
        private string _empid;

        protected override async Task OnInitializedAsync()
        {

            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            var queryStrings = QueryHelpers.ParseQuery(uri.Query);
            if(queryStrings.TryGetValue("EMPID", out var empid))
                {
                _empid = empid;
            }
            var response = await reportService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<List<Interview>>(response.response);
            var cerificationresponse = await reportService.GetCertificationDetails();
            certificationslist = Utility.GetResponseData<List<Certification>>(cerificationresponse.response);
            var powerHouseresponse = await benchServices.GeEACouncilEntryDetails();
            powerHouseDetails = Utility.GetResponseData<List<PowerHouse>>(powerHouseresponse.response);
            employeepoc = (await reportService.GetEmployeePOCDetails()).ToList();
            employee = (await reportService.GetEmployeeProjectDetails()).ToList();
            var learningresponse = await LearningService.GetLearnings();
            learningCompleteDetails = Utility.GetResponseData<List<Learning>>(learningresponse.response);
            var trainingresponse = await TrainingService.GetTrainings();
            trainingDetails = Utility.GetResponseData<List<Training>>(trainingresponse.response);
        }
    }
}
