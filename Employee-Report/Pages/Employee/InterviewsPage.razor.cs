using Employee_Report.API.IService;
using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Employee
{
    public partial class InterviewsPage
    {
        private readonly IInterviewService _interviewService;
        public InterviewsPage(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }
        public IEnumerable<Interview> interviewsDetails { get; set; }
        public Interview InterviewModel = new();
        private bool IsHidden { get; set; } = false;

        Repository.Services.SkillsService skillsService = new();
        IEnumerable<Skill> skillDetails = new List<Skill>();

        Repository.Services.GetRoleService roleService = new();
        IEnumerable<Role> roleDetails = new List<Role>();

        List<string> selectionlist = new List<string> { "Selected", "Rejected" };
        protected override async Task OnInitializedAsync()
        {
            var response = await _interviewService.GetInterviews();
            interviewsDetails = Utility.GetResponseData<IEnumerable<Interview>>(response.response);
            var skillResponse = await skillsService.GetSkills();
            skillDetails = Utility.GetResponseData<IEnumerable<Skill>>(skillResponse.response);

            var roleResponse = await roleService.GetRoleDetails();
            roleDetails = Utility.GetResponseData<IEnumerable<Role>>(roleResponse.response);
        }

        public async void AddInterview()
        {
            if (InterviewModel != null)
            {
                var response = await _interviewService.AddInterview(InterviewModel);
                if (response.status)
                {
                    navManager.NavigateTo("/Interviews", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        public void CancelInterview()
        {
            navManager.NavigateTo("/Interviews", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
