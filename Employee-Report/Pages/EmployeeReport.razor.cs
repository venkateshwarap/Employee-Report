using Employee.DataModel.Models;
using Employee_Report.API.Service;
using Employee_Report.Data;
using Employee_Report.Repository.IServices;
using Employee_Report.Repository.Services;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Employee_Report.Pages
{
    public partial class EmployeeReport
    {
        [Inject]
        IEmployeeSkillService employeeSkills { get; set; }
        Repository.Services.SkillsService SkillsService = new();
        public IEnumerable<Skill>? skillDetails { get; set; }
        public Skill skillModel = new();

        Repository.Services.EmployeesService employeesService = new Repository.Services.EmployeesService();
        public IEnumerable<Employees> employees { get; set; }



        ReportService reportService = new ReportService();
        public IEnumerable<Interview>? interviewsDetails { get; set; }
        public Interview InterviewModel = new();

        public List<Certification>? certificationslist = new();
        public Certification certifications = new();

        [Inject]
        public Repository.IServices.IPowerHouseService benchServices { get; set; }
        public IEnumerable<PowerHouse> powerHouseDetails { get; set; }
        public PowerHouse powerHouseModel = new();



        Repository.Services.EmployeePocService employeePocService = new Repository.Services.EmployeePocService();
        public IEnumerable<EmployeePOCEntity> employeepoc { get; set; }

        public EmployeePoc employeePocModel = new();

        public IEnumerable<EmployeeProject> employeeproject { get; set; }
        public EmployeeProject employeeProject = new();

        Repository.Services.LearningService LearningService = new();
        public IEnumerable<Learning>? learningCompleteDetails { get; set; }
        public Learning learningModel = new();

        Repository.Services.TrainingService TrainingService = new();
        public IEnumerable<Training>? trainingDetails  { get; set; }
        public Training trainingModel = new();
        public List<string> employeeskils = new();



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
        private string? _empid;
        private string? _name;
        protected override async Task OnInitializedAsync()
        {

            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            var queryStrings = QueryHelpers.ParseQuery(uri.Query);
            _empid = Utility.GetSessionClaim("EmployeeId");
            _name = Utility.GetSessionClaim("Name");
            var _resp_skils = await employeeSkills.GetEmployeeSkillsById(_empid);
            employeeskils = Utility.GetResponseData<List<string>>(_resp_skils.response);

            var response = await reportService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<List<Interview>>(response.response);
            var cerificationresponse = await reportService.GetCertificationById(_empid);
            var _cert_res_result = Utility.GetResponseData<Certification>(cerificationresponse.response);
            certificationslist.Add(_cert_res_result);
            var powerHouseresponse = await benchServices.GetPowerHouseById(_empid);
            var pocById = await reportService.GetEmployeePOCById(_empid);
            employeepoc = Utility.GetResponseData<List<EmployeePOCEntity>>(pocById.response);

            var res_employeeproject = await reportService.GetEmployeeProjectDetailsById(_empid);
            employeeproject = Utility.GetResponseData<List<EmployeeProject>>(res_employeeproject.response);
            var learningresponse = await LearningService.GetLearningsById(_empid);
            learningCompleteDetails = Utility.GetResponseData<List<Learning>>(learningresponse.response);
            var trainingresponse = await TrainingService.GetTrainingsById(_empid);
            trainingDetails = Utility.GetResponseData<List<Training>>(trainingresponse.response);
            employees = (await employeesService.GetEmployeeDetails()).ToList();

            //var skillresponse = await SkillsService.GetSkills();
            //skillDetails = Utility.GetResponseData<List<Skill>>(skillresponse.response);
        }
        protected async Task ExportToPdf()
        {
            ExportService exportService = new ExportService();
            using (MemoryStream excelStream = exportService.CreatePdf())
            {
                await JS.SaveAs("EmployeeReport.pdf", excelStream.ToArray());
            }

        }

    }
}
