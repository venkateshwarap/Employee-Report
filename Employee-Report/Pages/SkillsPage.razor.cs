using Employee.DataModel.Models;
using Employee_Report.Model.Models;
using Employee_Report.Utilities;

namespace Employee_Report.Pages
{
    public partial class SkillsPage
    {
        Repository.Services.SkillsService SkillsService = new();
        public IEnumerable<Skill> skillsDetails { get; set; }
        public string skills { get; set; }
        public Skill skillsModel = new();
        private bool IsHidden { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            var response = await SkillsService.GetSkills();
            skills = response;
        }
        public async void addSkill()
        {
            if (skillsModel != null)
            {
                var response = await SkillsService.AddSkill(skillsModel);
                if (response.status)
                {
                    navManager.NavigateTo("/skills", forceLoad: true);
                    IsHidden = false;
                }
            }
        }
        private void AddClass()
        {
            IsHidden = !IsHidden;
        }
    }
}
