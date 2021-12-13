namespace DesignPatternsDemosClient.Extensions;

public static class AcordExtensions
{
    public static bool HasGeneralLiability(this Acord acord)
    {
        return (acord.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness == null);
    }

    public static decimal GetCoverageValue(this LiabilityInfo liabilityInfo, string coverageCode, string limitCode, decimal defaultValue)
    {
        var commlCoverage = liabilityInfo.CommlCoverage.FirstOrDefault(c => c.CoverageCd == coverageCode);
        if (commlCoverage == null) return defaultValue;

        var value = (from limit in commlCoverage.Limits
            where limit.LimitAppliesToCd == limitCode
            select limit.FormatCurrencyAmt?.Amt).FirstOrDefault();

        return value ?? defaultValue;
    }

    public static string? GetLimitValue(this LiabilityInfo liabilityInfo, string coverageCode)
    {
        var commlCoverage = liabilityInfo.CommlCoverage.FirstOrDefault(c => c.CoverageCd == coverageCode);
        if (commlCoverage == null) return null;

        var limit = commlCoverage.Limits.FirstOrDefault();
        var amt = limit?.FormatCurrencyAmt?.Amt;

        if (amt.HasValue) return amt.Value.ToString(CultureInfo.InvariantCulture);

        limit = commlCoverage.Limits.FirstOrDefault(l => !string.IsNullOrWhiteSpace(l.LimitAppliesToCd));
        return limit?.LimitAppliesToCd;
    }
}