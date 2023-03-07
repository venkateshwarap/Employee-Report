using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Employee_Report.Model.Models;
using Microsoft.AspNetCore.Http;
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
        [Route("create")]
        public async Task<IActionResult> CreateCertificationDetails(Certifications certifications)
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
        [Route("get")]
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

        [HttpPost]
        [Route("getbyId")]
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
        [Route("delete")]
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
