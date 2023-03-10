using Employee.DataModel.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class CertificationService : ICertificationService
    {
        private EatrackingContext _context;
        public CertificationService(EatrackingContext context)
        {
            _context = context;
        }
        public async Task<Response> CreateCertificationDetails(Certification certifications)
        {
            await _context.Certifications.AddAsync(certifications);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return BindResponse(result, true, Constants.Response_Create_Certification);
            }
            {
                return BindResponse(result, false);
            }
        }

        public async Task<Response> GetCertificationDetails()
        {
            var result = await _context.Certifications.ToListAsync();
            if (result.Count > 0)
            {
                return BindResponse(result, true);
            }
            {
                return BindResponse(result, false);
            }
        }
        public async Task<Response> GetCertificationDetailsById(string empid)
        {
            var result = await _context.Certifications.Where(x => x.EmpId == empid).FirstOrDefaultAsync();
            if (result != null)
            {
                return BindResponse(result!, true);
            }
            {
                return BindResponse(result!, false);
            }
        }

        public async Task<Response> Delete(string empid)
        {
            var result = await _context.Certifications.Where(x => x.EmpId == empid).FirstOrDefaultAsync();
            if (result == null)
            {
                return BindResponse(result!, false, Constants.RE_EmpId_Not_Available_EA);
            }
            _context.Certifications.Remove(result!);
            var response = await _context.SaveChangesAsync();

            if (response == 1)
            {
                return BindResponse(result!, true, Constants.Response_Remove_Certification);
            }
            {
                return BindResponse(result!, false);
            }
        }

        private Response BindResponse(Object Obj = null!, bool Status = true, string Message = "")
        {
            Response resp = new Response();
            resp.response = Obj;
            resp.message = Message;
            resp.status = Status;
            return resp;
        }
    }
}
