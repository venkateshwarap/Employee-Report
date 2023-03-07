using Employee_Report.Repository.Services;
using EmployeeDetails.Api.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages
{
    public partial class EmployeeReport
    {
        [Inject]
        public InterviewService interviewService { get; set; }
        public IEnumerable<Interview> interviewsDetails { get; set; }
        public Interview InterviewModel = new();
        [Inject]
        public EACouncilService benchServices { get; set; }
        public IEnumerable<EACouncilEntryExit> benchdetails { get; set; }
        public EACouncilEntryExit entryExit = new();
        public List<ChartDataModel> pieData;
        public List<Projects> projects { get; set; }
        public List<Learnings> learning { get; set; }
        public List<Certifications> certifications { get; set; }
        public List<Trainings> trainings { get; set; }
        public List<ProofOfConcepts> proofOfConcepts { get; set; }
        public List<IntellectualProperties> intellectualproperties { get; set; }
        public List<EACouncil> eACouncils { get; set; }
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
        protected override async Task OnInitializedAsync()
        {

            var response = await interviewService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<List<Interview>>(response.response);

            var benchresponse = await benchServices.GetBenchEntry();
            benchdetails = Utility.GetResponseData<List<EACouncilEntryExit>>(response.response);

            learning = new List<Learnings>
        {
                  new Learnings() {  Name = "C# Advanced",Path = "https://pluralsight.com/CsharpAdvanced",HoursOfLearning=10, StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  },
        new Learnings() {  Name = "ASP.NET SIGNALIR",Path = "https://pluralsight.com/SIGNALIR",HoursOfLearning=10, StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  },

        };
            proofOfConcepts = new List<ProofOfConcepts>
    {
        new ProofOfConcepts() {  Name = "Commport",Role = "Team Lead",
        ReportingTo = "Lakshumaiah", StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  },
        new ProofOfConcepts() {  Name = "CWF",Role = "Team Lead",ReportingTo="Srinivas",
        StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  }
    };
            intellectualproperties = new List<IntellectualProperties>
    {
      new IntellectualProperties() {  Name = "Commport",Role = "Team Lead",
        ReportingTo = "Lakshumaiah", StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  },
        new IntellectualProperties() {  Name = "CWF",Role = "Team Lead",ReportingTo="Srinivas",
        StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  }
    };
            eACouncils = new List<EACouncil>
    {
      new EACouncil() {  Role = "Team Lead",
        ReportingTo = "Lakshumaiah", StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  },
        new EACouncil() {  Role = "Team Lead",ReportingTo="Srinivas",
        StartDate = new DateTime(2021, 8, 4, 12, 0, 0)  ,EndDate = new DateTime(2021, 9, 6, 12, 0, 0)  }
    };
            projects = new List<Projects>()
        {
            new Projects() { Name = "Advent", Role = "Team Lead", EmpProjectStartDate = new DateTime(2021, 8, 4, 12, 0, 0),EmpProjectEndDate = new DateTime(2021, 9, 6, 12, 0, 0), ReportingTo = " Sandeep" },
            new Projects() { Name = "Vertafore", Role = "Team Lead", EmpProjectStartDate = new DateTime(2022, 8, 4, 12, 0, 0) ,EmpProjectEndDate = new DateTime(2022, 9, 9, 12, 0, 0), ReportingTo = "Srinivas" },
        };
            trainings = new List<Trainings>()
        {
            new Trainings() { Name = "C# Advanced", HoursOfLearning   = 10, StartDate = new DateTime(2021, 8, 4, 12, 0, 0),EndDate = new DateTime(2021, 9, 6, 12, 0, 0) },
            new Trainings() { Name = "Vertafore", HoursOfLearning = 10, StartDate = new DateTime(2022, 8, 4, 12, 0, 0) ,EndDate = new DateTime(2022, 9, 9, 12, 0, 0)},
        };
            certifications = new List<Certifications>()
        {
            new Certifications() { Name = "Azure Associate Architech", ValidFrom = new DateTime(2020, 8, 4, 12, 0, 0), ValidTo = new DateTime(2021, 8, 4, 12, 0, 0) },
        };
        }
        public class Projects
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public DateTime EmpProjectStartDate { get; set; }
            public DateTime EmpProjectEndDate { get; set; }
            public string ReportingTo { get; set; }
        }
        public class Trainings
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int HoursOfLearning { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        public class ProofOfConcepts
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string ReportingTo { get; set; }
        }
        public class Certifications
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime ValidFrom { get; set; }
            public DateTime ValidTo { get; set; }
        }
        public class Learnings
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
            public int HoursOfLearning { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        public class IntellectualProperties
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string ReportingTo { get; set; }
        }
        public class EACouncil
        {
            public int Id { get; set; }
            public string Role { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string ReportingTo { get; set; }
        }
        public class EACouncilEntryExit
        {
            public int Id { get; set; }
            public string? EmpId { get; set; }
            public DateTime StartDate { get; set; } = DateTime.Now;
            public DateTime EndDate { get; set; } = DateTime.Now;
            public string? Role { get; set; }
            public string? ReportingTo { get; set; }
        }
        public class Interview
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Role { get; set; } = null!;
            public string Status { get; set; } = null!;
            public DateTime Date { get; set; } = DateTime.Now;
            public string ReportingTo { get; set; } = null!;
        }
    }
}
