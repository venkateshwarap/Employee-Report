using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components;

namespace Employee_Report.Pages.Employee
{
    public partial class InterviewsPage
    {
        [Inject]
        private  IInterviewService _interviewService { get; set; }

        [Inject]
        private ISkillsService skillsService { get; set; }
        [Inject]
        private IGetRoleService roleService { get; set; }
        public IEnumerable<Interview> interviewsDetails { get; set; }
        public Interview InterviewModel = new();
        private bool IsHidden { get; set; } = false;

        IEnumerable<Skill> skillDetails = new List<Skill>();

        
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
                var response = await _interviewService.CreateInterview(InterviewModel);
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
