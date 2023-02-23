namespace SCMDWH.Client
{
    public static class Helpers
    {
             public static string  ChangeDateToString(DateTime dateToBeChange)
            {
            string mc = string.Empty;
            string day = string.Empty;
            string stringData = string.Empty;
            if (dateToBeChange.Month < 10) { mc = "0" + dateToBeChange.Month.ToString(); } else { mc = dateToBeChange.Month.ToString(); }
            if (dateToBeChange.Day < 10) { day = "0" + dateToBeChange.Day.ToString(); } else { day = dateToBeChange.Day.ToString();}

            stringData= mc + day+ dateToBeChange.Year.ToString();

            return stringData;
            }
    }
}
