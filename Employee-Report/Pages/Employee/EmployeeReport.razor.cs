using Employee_Report.Model.Models;
using Employee_Report.Data;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;
using Employee_Report.Repository.Services;
using Employee_Report.Model.ModelView;

namespace Employee_Report.Pages.Employee
{
    public partial class EmployeeReport
    {
        [Inject]
        private IEmployeeSkillService employeeSkills { get; set; }
        [Inject]
        private IInterviewService interviwService { get; set; }

        [Inject]
        private IEmployeesService employeesService { get; set; }

        [Inject]
        private IPowerHouseService benchServices { get; set; }

        [Inject]
        private IEmployeeLearningService learningService { get; set; }

        [Inject]
        private ITrainingService trainingService { get; set; }
        [Inject]
        private IEmployeePocService employeePocService { get; set; }

        [Inject]
        private ICertificationsService certificationsService { get; set; }

        [Inject]
        private IEmployeeProjectService projectService { get; set; }
        public IEnumerable<Skill> skillDetails { get; set; }
        public Skill skillModel = new();
        public IEnumerable<Employees> employees { get; set; }
        public IEnumerable<Interview> interviewsDetails { get; set; }
        public Interview InterviewModel = new();

        public IEnumerable<Certification> certificationslist  { get; set; }
        public Certification certifications = new();
        public IEnumerable<PowerHouse> powerHouseDetails { get; set; }
        public PowerHouse powerHouseModel = new();
        public IEnumerable<EmployeePOCEntity> employeepoc { get; set; }

        public EmployeePoc employeePocModel = new();
        public IEnumerable<EmployeeProject> employeeproject { get; set; }
        public EmployeeProject employeeProject = new();
        public IEnumerable<Learning> learningCompleteDetails { get; set; }
        public Learning learningModel = new();
        public IEnumerable<Training> trainingDetails { get; set; }
        public Training trainingModel = new();
        public List<EmployeeSkillView> employeeskils = new();
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
        private string _name;
        protected override async Task OnInitializedAsync()
        {
            _empid = Utility.GetSessionClaim("EmployeeId");
            _name = Utility.GetSessionClaim("Name");
            var _resp_skils = await employeeSkills.GetEmployeeSkillsById(_empid);
            employeeskils = Utility.GetResponseData<List<EmployeeSkillView>>(_resp_skils.response);

            var response = await interviwService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<List<Interview>>(response.response);
            var cerificationresponse = await certificationsService.GetCertificationById(_empid);
            certificationslist = Utility.GetResponseData<IEnumerable<Certification>>(cerificationresponse.response);
            var powerHouseresponse = await benchServices.GetPowerHouseById(_empid);
            powerHouseDetails = Utility.GetResponseData<IEnumerable<PowerHouse>>(powerHouseresponse.response);
            var pocById = await employeePocService.GetEmployeePOCById(_empid);
            employeepoc = Utility.GetResponseData<IEnumerable<EmployeePOCEntity>>(pocById.response);
            var res_employeeproject = await projectService.GetEmployeeProjectDetailsById(_empid);
            employeeproject = Utility.GetResponseData<IEnumerable<EmployeeProject>>(res_employeeproject.response);
            var learningresponse = await learningService.GetEmployeeLearningById(_empid);
            learningCompleteDetails = Utility.GetResponseData<IEnumerable<Learning>>(learningresponse.response);
            var trainingresponse = await trainingService.GetTrainingsById(_empid);
            trainingDetails = Utility.GetResponseData<IEnumerable<Training>>(trainingresponse.response);
            var res_employee= await employeesService.GetEmployeeDetails();
            employees = Utility.GetResponseData<IEnumerable<Employees>>(res_employee.response);

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
