using CMSAPI.Models;

public interface IPolicyRepository
{
    List<Policy> GetPolicies();
    Policy GetPolicyById(int pid);
    List<Policy> CreatePolicy(Policy policy);
    List<Policy> UpdatePolicy(Policy policy);
    List<Policy> DeletePolicy(int pid);
    List<UserPolicy> GetMyPolicies(int uid);
    bool AddPolicy(UserPolicy policy);
    List<Policy> _GetRelevantPolicy(string ptype, string Gender, string AgeGroup, string Members,int grade);

}