using Employee.DataModel.Models;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class IntelleactualPropertyService : IIntelleactalProperty
    {
        private readonly EmployeeInfoContext _context;
        public IntelleactualPropertyService(EmployeeInfoContext context)
        {
            _context = context;
        }

        public async Task<Response> GetAll()
        {
          var resp = await _context.IntelleactualProperty.ToListAsync();
            if(resp.Count > 0) 
            {
               return APIUtility.BindResponse(resp!, true);
            }

            return APIUtility.BindResponse(resp!, false);
        }

        public async Task<Response> GetById(string empid)
        {
            var resp = await _context.IntelleactualProperty.Where(x=>x.EmpId == empid).FirstOrDefaultAsync();
            if (resp != null)
            {
                return APIUtility.BindResponse(resp!, true);
            }

            return APIUtility.BindResponse(resp!, false);
        }

        public async Task<Response> Create(IntelleactualProperty intelleactual)
        {
           var result = await _context.AddAsync(intelleactual);
           var response = _context.SaveChanges();
            if (response == 1)
            {
                return APIUtility.BindResponse(response!, true, "IntelleactualProperty has been created");
            }

            return APIUtility.BindResponse(response!, false);
        }

        public async Task<Response> Update(IntelleactualProperty intelleactual)
        {
            var result = await _context.IntelleactualProperty.Where(x => x.EmpId == intelleactual.EmpId).FirstOrDefaultAsync();
            if (result == null)
            {
                return APIUtility.BindResponse(result!, false, "Intelleactual Property has been create");
            }
            result.StartDate = intelleactual.StartDate;
            result.EndDate = intelleactual.EndDate;
            _context.IntelleactualProperty.Update(result!);
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
            var result = await _context.IntelleactualProperty.Where(x => x.EmpId == empid).FirstOrDefaultAsync();
            _context.IntelleactualProperty.Remove(result!);
            var resp = _context.SaveChanges();
            if (result == null)
            {
                return APIUtility.BindResponse(result!, false, "Intelleactual Property has been delete");
            }
           return APIUtility.BindResponse(result!, false, "Intelleactual Property has been not delete");
        }
    }
}
