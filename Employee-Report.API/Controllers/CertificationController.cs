using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Report.API.Controllers
{
    [Route(Constants.RT_Certification)]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certification;
        public CertificationController(ICertificationService certification)
        {
            _certification = certification;
        }

        [HttpPost]
        [Route(Constants.CREATE)]
        public async Task<IActionResult> CreateCertificationDetails(Certification certifications)
        {
            try
            {
                var result = await _certification.CreateCertificationDetails(certifications);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [Route(Constants.GET)]
        public async Task<IActionResult> GetCertificationDetails()
        {
            try
            {
                var result = await _certification.GetCertificationDetails();
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [Route(Constants.GET_BY_ID)]
        public async Task<IActionResult> GetCertificatioDetailsById(string empid)
        {
            try
            {
                var result = await _certification.GetCertificationDetailsById(empid);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        [Route(Constants.DELETE)]
        public async Task<IActionResult> DeleteCertificationDetails(string empid)
        {
            try
            {
                var result = await _certification.Delete(empid);
                if (result.status)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
