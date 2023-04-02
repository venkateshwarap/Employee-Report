using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages.Admin
{
    public partial class SkillsPage
    {
        Repository.Services.SkillsService SkillsService = new();
        public IEnumerable<Skill> skillDetails { get; set; }
        public Skill skillModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await SkillsService.GetSkills();
            skillDetails = Utility.GetResponseData<List<Skill>>(response.response);
        }

        public async void AddSkill()
        {
            if (skillModel != null)
            {
                var response = await SkillsService.AddSkill(skillModel);
                if (response.status)
                {
                    navManager.NavigateTo("/skills", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void cancelSkill()
        {
            navManager.NavigateTo("/skills", forceLoad: true);
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
