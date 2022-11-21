using CMSAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace CMSAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class PolicyController : ControllerBase
{
    private IPolicyRepository _iPolicyRepository;

    public PolicyController(IPolicyRepository PolicyRepository)
    {
        _iPolicyRepository = PolicyRepository;
    }

    [HttpGet]
    public List<Policy> GetAllPolicies()
    {
        return _iPolicyRepository.GetPolicies();
    }

    [HttpGet("GetAllPoliciesJson")]
    public string GetAllPoliciesJson()
    {
        var result = _iPolicyRepository.GetPolicies();
        return JsonSerializer.Serialize(result);
    }

    [HttpGet("{pid:int}")]
    public Policy GetPolicyById(int pid)
    {
        return _iPolicyRepository.GetPolicyById(pid);
    }
    [HttpGet("GetRelevantPolicyJson/{ptype}/{Gender}/{AgeGroup}/{Members}/{pgrade}")]
    public string GetRelevantPolicyJson(string ptype, string Gender, string AgeGroup, string Members, int pgrade)
    {
        var result = _iPolicyRepository._GetRelevantPolicy(ptype, Gender, AgeGroup, Members,pgrade);
        return JsonSerializer.Serialize(result);
    }

    [Authorize]
    [HttpPost]
    public List<Policy> CreateNewPolicy(Policy policy)
    {
        return _iPolicyRepository.CreatePolicy(policy);
    }

    [Authorize]
    [HttpPut]
    public List<Policy> UpdatePolicy(Policy policy)
    {
        return _iPolicyRepository.UpdatePolicy(policy);
    }
    
    [Authorize]
    [HttpDelete("{pid:int}")]
    public List<Policy> DeletePolicy(int pid)
    {
        return _iPolicyRepository.DeletePolicy(pid);
    }

    //Test Branches
}