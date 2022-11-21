using CMSAPI.Models;

public class PolicyRepository : IPolicyRepository
{
    private List<Policy> _Policies;
    public PolicyRepository()
    {
        _Policies = new List<Policy>();
        _Policies.Add(new Policy
        {
            pid = 1,
            pname = "Group Mediclaim Policy",
            pdesc_short = "ShortDescription",
            pdesc = "Health insurance takes care of your medical expenses and ensures that out-of-pocket expenses are curtailed up to the Sum insured",
            ptype = "GMC",
            pCoverage = 300000.00,
            pPremium = 3761,
            Gender = "M",
            AgeGroup = "18-30",
            Members = "U",
            Insurer = "ICICI",
            pgrade = 12,
            pstatus = "A"

        });
        _Policies.Add(new Policy
        {
            pid = 11,
            pname = "Group Mediclaim Policy 2",
            pdesc_short = "ShortDescription",
            pdesc = "Health insurance takes care of your medical expenses upto 600000 and ensures that out-of-pocket expenses are curtailed up to the Sum insured",
            ptype = "GMC",
            pCoverage = 600000.00,
            pPremium = 6361,
            Gender = "M",
            AgeGroup = "18-30",
            Members = "U",
            Insurer = "HDFC",
            pgrade = 12,
            pstatus = "A"

        });
        _Policies.Add(new Policy
        {
            pid = 2,
            pname = "GPAPolicy1",
            pdesc_short = "ShortDescription",
            pdesc = "Health insurance takes care of your medical expenses and ensures that out-of-pocket expenses are curtailed up to the Sum insured",
            ptype = "GPA",
            pCoverage = 800000.00,
            pPremium = 8761,
            Gender = "F",
            AgeGroup = "18-30",
            Members = "U+C",
            Insurer="SBI",
            pgrade = 11,
            pstatus = "A"
        });
        _Policies.Add(new Policy
        {
            pid = 3,
            pname = "GTLPolicy1",
            pdesc_short = "ShortDescription",
            pdesc = "Health insurance takes care of your medical expenses and ensures that out-of-pocket expenses are curtailed up to the Sum insured",
            ptype = "GTL",
            pCoverage = 2000000.00,
            pPremium = 20761,
            Gender = "M",
            AgeGroup = "18-30",
            Members = "U+S",
            Insurer = "NATIONAL",
            pgrade = 10,
            pstatus = "A"
        });
        _Policies.Add(new Policy
        {
            pid = 4,
            pname = "GTLPolicy2",
            pdesc_short = "ShortDescription",
            pdesc = "Health insurance takes care of your medical expenses and ensures that out-of-pocket expenses are curtailed up to the Sum insured",
            ptype = "GTL",
            pCoverage = 10000000.00,
            pPremium = 22000,
            Gender = "M",
            AgeGroup = "18-30",
            Members = "A",
            Insurer = "ICICI",
            pgrade = 1,
            pstatus = "A"
        });
    }
    public List<Policy> CreatePolicy(Policy policy)
    {
        int NoOfRecords = _Policies.Count();
        policy.pid = 1;
        if (NoOfRecords > 0)
        {
            policy.pid = _Policies.Max(p => p.pid) + 1;
        }
        _Policies.Add(policy);
        return _Policies;

    }

    public List<Policy> DeletePolicy(int pid)
    {
        var result = _Policies.Where(p => p.pid == pid).FirstOrDefault();
        if (result != null)
        {
            _Policies.Remove(result);
        }
        return _Policies;
    }

    public List<Policy> GetPolicies()
    {
        return _Policies;
    }

    public Policy GetPolicyById(int pid)
    {
        Policy policy = new Policy();
        var result = _Policies.Where(p => p.pid == pid).FirstOrDefault();
        if (result != null)
            return result;
        else
            return policy;
    }

    public List<Policy> UpdatePolicy(Policy policy)
    {
        int i = _Policies.FindIndex(p => p.pid == policy.pid);
        if (i >= 0)
        {
            _Policies[i].pname = policy.pname;
            _Policies[i].ptype = policy.ptype;
            _Policies[i].pgrade = policy.pgrade;
        }
        return _Policies;
    }
    public List<Policy> _GetRelevantPolicy(string ptype, string Gender, string AgeGroup, string Members, int pGrade)
    {
        Policy policy = new Policy();
        var result = _Policies.Where(_p => _p.ptype == ptype
            & _p.Gender == Gender
            & _p.AgeGroup == AgeGroup
            & _p.Members == Members
            & _p.pgrade == pGrade);
        return result.ToList();
        // if (result != null)
        //     return result;
        // else
        //     return policy;
    }
}