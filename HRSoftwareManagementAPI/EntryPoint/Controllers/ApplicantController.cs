using EntryPoint.DTOs;
using EntryPoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntryPoint.Controllers;

[ApiController]
[Route("api/v1/applicants")]
public class ApplicantController : ControllerBase
{
    private readonly ILogger<ApplicantController> _logger;
    private readonly IApplicantService _applicantService;

    public ApplicantController(ILogger<ApplicantController> logger, IApplicantService applicantService)
    {
        _logger = logger;
        _applicantService = applicantService;
    }
    
    [HttpPost]
    public ActionResult CreateApplicant(ApplicantDto applicant)
    {
        try
        {
            var createdApplicant = _applicantService.CreateApplicant(applicant);
            return Ok(createdApplicant);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            throw;
        }
    }
    
    [HttpPut]
    [Route("{applicantId:int}")]
    public ActionResult UpdateApplicant(ApplicantDto applicant, int applicantId)
    {
        applicant.Id = applicantId;
        try
        {
            var createdApplicant = _applicantService.UpdateApplicant(applicant);
            return Ok(createdApplicant);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            throw;
        }
    }
    
    [HttpDelete]
    [Route("{applicantId:int}")]
    public ActionResult DeleteApplicantWithId(int applicantId)
    {
        try
        {
            _applicantService.DeleteApplicantWithId(applicantId);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            throw;
        }
    }
}