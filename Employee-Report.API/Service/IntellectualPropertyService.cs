using Employee_Report.Model.Models;
using Employee_Report.API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class IntellectualPropertyService : IIntelleactalProperty
    {
        private readonly EmployeeInfoContext _context;
        public IntellectualPropertyService(EmployeeInfoContext context)
        {
            _context = context;
        }

        public async Task<Response> GetAll()
        {
          var resp = await _context.IntellectualProperty.ToListAsync();
            if(resp.Count > 0) 
            {
               return APIUtility.BindResponse(resp!, true);
            }

            return APIUtility.BindResponse(resp!, false);
        }

        public async Task<Response> GetById(string empid)
        {
            var resp = await _context.IntellectualProperty.Where(x=>x.EmpId == empid).FirstOrDefaultAsync();
            if (resp != null)
            {
                return APIUtility.BindResponse(resp!, true);
            }

            return APIUtility.BindResponse(resp!, false);
        }

        public async Task<Response> Create(IntellectualProperty intelleactual)
        {
           var result = await _context.AddAsync(intelleactual);
           var response = _context.SaveChanges();
            if (response == 1)
            {
                return APIUtility.BindResponse(response!, true, "IntelleactualProperty has been created");
            }

            return APIUtility.BindResponse(response!, false);
        }

        public async Task<Response> Update(IntellectualProperty intelleactual)
        {
            var result = await _context.IntellectualProperty.Where(x => x.EmpId == intelleactual.EmpId).FirstOrDefaultAsync();
            if (result == null)
            {
                return APIUtility.BindResponse(result!, false, "Intelleactual Property has been create");
            }
            result.StartDate = intelleactual.StartDate;
            result.EndDate = intelleactual.EndDate;
            _context.IntellectualProperty.Update(result!);
            var response = await _context.SaveChangesAsync();

            if (response == 1)
            {
                return APIUtility.BindResponse(result!, true, Constants.Response_Remove_Certification);
            }
            {
                return APIUtility.BindResponse(result!, false);
            }
        }

        public async Task<Response> Delete(string empid)
        {
            var result = await _context.IntellectualProperty.Where(x => x.EmpId == empid).FirstOrDefaultAsync();
            _context.IntellectualProperty.Remove(result!);
            var resp = _context.SaveChanges();
            if (result == null)
            {
                return APIUtility.BindResponse(result!, false, "Intelleactual Property has been delete");
            }
           return APIUtility.BindResponse(result!, false, "Intelleactual Property has been not delete");
        }
    }
}
