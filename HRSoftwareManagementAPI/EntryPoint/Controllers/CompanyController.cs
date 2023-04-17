using Core.UseCases.Exceptions;
using EntryPoint.DTOs;
using EntryPoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntryPoint.Controllers;

[ApiController]
[Route("api/v1/companies")]
public class CompanyController : ControllerBase
{
    private readonly ILogger<CompanyController> _logger;
    private readonly ICompanyService _companyService;
    private readonly IApplicantService _applicantService;

    public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger,
        IApplicantService applicantService)
    {
        _companyService = companyService;
        _logger = logger;
        _applicantService = applicantService;
    }

    [HttpGet]
    [Route("{companyId:int}")]
    public ActionResult GetCompany(int companyId)
    {
        try
        {
            var company = _companyService.GetCompanyById(companyId);
            return Ok(company);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            return NotFound();
        }
    }

    [HttpGet]
    [Route("{companyId:int}/applicants")]
    public ActionResult GetCompanyApplicants(int companyId)
    {
        try
        {
            var applicants = _applicantService.GetApplicantsByCompanyId(companyId);
            return Ok(applicants);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            return NotFound();
        }
    }

    [HttpGet]
    public ActionResult GetCompanies()
    {
        try
        {
            var companies = _companyService.GetCompanies();
            return Ok(companies);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult CreateCompany(CompanyDto company)
    {
        try
        {
            var createdCompany = _companyService.CreateCompany(company);
            return Ok(createdCompany);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            throw;
        }
    }

    [HttpPut]
    [Route("{companyId:int}")]
    public ActionResult UpdateCompany(CompanyDto company, int companyId)
    {
        company.Id = companyId;
        try
        {
            var createdCompany = _companyService.UpdateCompany(company);
            return Ok(createdCompany);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            throw;
        }
    }
    
    [HttpDelete]
    [Route("{companyId:int}")]
    public ActionResult DeleteCompanyWithId(int companyId)
    {
        try
        {
            _companyService.DeleteCompanyWithId(companyId);
            return Ok();
        }
        catch (CompanyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError("Error {}", e);
            throw;
        }
    }
}