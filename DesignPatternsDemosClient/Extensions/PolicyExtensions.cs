namespace DesignPatternsDemosClient.Extensions;

public static class PolicyExtensions
{
    public static bool HasGeneralLiability(this PolicyRoot policy)
    {
        return policy.GeneralLiability == null;
    }
}