using System;

public class DateModifier
{
    private const string DateFormat = "yyyy MM dd";
    private string firstDateStr;
    private string secondDateStr;
    private int differenceInDays;

    public DateModifier(string firstDateStr, string secondDateStr)
    {
        this.FirstDateStr = firstDateStr;
        this.SecondDateStr = secondDateStr;
    }

    public string FirstDateStr
    {
        get => firstDateStr;
        set => firstDateStr = value;
    }

    public string SecondDateStr
    {
        get => secondDateStr;
        set => secondDateStr = value;
    }

    public int DifferenceInDays
    {
        get
        {
            CalcDifferenceInDays();

            return differenceInDays;
        }

        private set => differenceInDays = value;
    }

    private DateTime ParseDate(string dateStr)
    {
        DateTime date = DateTime.ParseExact(dateStr, DateFormat, null);

        return date;
    }

    private void CalcDifferenceInDays()
    {
        DateTime firstDate = ParseDate(this.firstDateStr);
        DateTime secondDate = ParseDate(this.secondDateStr);

        TimeSpan span = firstDate - secondDate;

        this.DifferenceInDays = Math.Abs(span.Days);
    }
}