using System;
using System.Collections.Generic;

public class HumanTimeFormat
{
  private const int minuteInSeconds = 60, hourInSeconds = 60 * minuteInSeconds, dayInSeconds = 24 * hourInSeconds, yearInSeconds = 365 * dayInSeconds;

  public static string formatDuration(int inputInSeconds)
  {
    if (inputInSeconds == 0) return "now";

    Dictionary<string, int> split = new(){
      {"year", 0},
      {"day", 0},
      {"hour", 0},
      {"minute", 0},
      {"second", 0}
    };

    string answerYear = "", answerDay = "", answerHour = "", answerMinute = "", answerSecond = "";
    List<string> ListOfAnswerNotWhite = [];


    if (inputInSeconds < minuteInSeconds)
    {
      split["second"] = inputInSeconds;
      answerSecond = $"{split["second"]} second";
    }
    else if (inputInSeconds < hourInSeconds)
    {
      split["minute"] = inputInSeconds / minuteInSeconds;
      split["second"] = inputInSeconds - split["minute"] * minuteInSeconds;

      answerMinute = $"{split["minute"]} minute{AddSifSuperiorTo1(split["minute"])}";
      if (split["second"] > 0) answerSecond = $"and {split["second"]} seconds";
    }
    else if (inputInSeconds < dayInSeconds)
    {
      InputIsLessThanOneDayButGreaterThanOneHour(inputInSeconds, split, ref answerHour, ref answerMinute, ref answerSecond);
    }
    else if (inputInSeconds < yearInSeconds)
    {
      InputIsLessThanOneYearButGreaterThanOneMonth(inputInSeconds, split, ref answerDay, ref answerHour, ref answerMinute, ref answerSecond);
    }
    else
    {
      answerYear = InputIsGreaterThanOneYear(inputInSeconds, split, ref answerDay, ref answerHour, ref answerMinute, ref answerSecond);
    }

    if (answerYear != "") ListOfAnswerNotWhite.Add(answerYear);
    if (answerDay != "") ListOfAnswerNotWhite.Add(answerDay);
    if (answerHour != "") ListOfAnswerNotWhite.Add(answerHour);
    if (answerMinute != "") ListOfAnswerNotWhite.Add(answerMinute);
    if (answerSecond != "") ListOfAnswerNotWhite.Add(answerSecond);

    return AddSpaceBetweenSplits(ListOfAnswerNotWhite);
  }

  private static void InputIsLessThanOneDayButGreaterThanOneHour(int inputInSeconds, Dictionary<string, int> split, ref string answerHour, ref string answerMinute, ref string answerSecond)
  {
    split["hour"] = inputInSeconds / hourInSeconds;
    split["minute"] = (inputInSeconds - split["hour"] * hourInSeconds) / minuteInSeconds;
    split["second"] = inputInSeconds - split["hour"] * hourInSeconds - split["minute"] * minuteInSeconds;

    if (split["hour"] > 0) answerHour = $"{split["hour"]} hour{AddSifSuperiorTo1(split["hour"])}";
    if (split["minute"] > 0) answerMinute = $"{split["minute"]} minute{AddSifSuperiorTo1(split["minute"])}";
    if (split["second"] > 0) answerSecond = $"{split["second"]} second{AddSifSuperiorTo1(split["second"])}";
    if (split["second"] > 0) answerSecond = "and " + answerSecond;
    else if (split["minute"] > 0) answerMinute = "and " + answerMinute;
  }

  private static void InputIsLessThanOneYearButGreaterThanOneMonth(int inputInSeconds, Dictionary<string, int> split, ref string answerDay, ref string answerHour, ref string answerMinute, ref string answerSecond)
  {
    split["day"] = inputInSeconds / dayInSeconds;
    split["hour"] = (inputInSeconds - split["day"] * dayInSeconds) / hourInSeconds;
    split["minute"] = (inputInSeconds - split["day"] * dayInSeconds - split["hour"] * hourInSeconds) / minuteInSeconds;
    split["second"] = inputInSeconds - split["day"] * dayInSeconds - split["hour"] * hourInSeconds - split["minute"] * minuteInSeconds;

    if (split["day"] > 0) answerDay = $"{split["day"]} day{AddSifSuperiorTo1(split["day"])}";
    if (split["hour"] > 0) answerHour = $"{split["hour"]} hour{AddSifSuperiorTo1(split["hour"])}";
    if (split["minute"] > 0) answerMinute = $"{split["minute"]} minute{AddSifSuperiorTo1(split["minute"])}";
    if (split["second"] > 0) answerSecond = $"{split["second"]} second{AddSifSuperiorTo1(split["second"])}";

    if (split["second"] > 0) answerSecond = "and " + answerSecond;
    else if (split["minute"] > 0) answerMinute = "and " + answerMinute;
    else if (split["hour"] > 0) answerHour = "and " + answerHour;
  }


  private static string InputIsGreaterThanOneYear(int inputInSeconds, Dictionary<string, int> split, ref string answerDay, ref string answerHour, ref string answerMinute, ref string answerSecond)
  {
    string answerYear;
    split["year"] = inputInSeconds / yearInSeconds;
    split["day"] = (inputInSeconds - split["year"] * yearInSeconds) / dayInSeconds;
    split["hour"] = (inputInSeconds - split["year"] * yearInSeconds - split["day"] * dayInSeconds) / hourInSeconds;
    split["minute"] = (inputInSeconds - split["year"] * yearInSeconds - split["day"] * dayInSeconds - split["hour"] * hourInSeconds) / minuteInSeconds;
    split["second"] = inputInSeconds - split["year"] * yearInSeconds - split["day"] * dayInSeconds - split["hour"] * hourInSeconds - split["minute"] * minuteInSeconds;

    answerYear = $"{split["year"]} year{AddSifSuperiorTo1(split["year"])}";
    if (split["day"] > 0) answerDay = $"{split["day"]} day{AddSifSuperiorTo1(split["day"])}";
    if (split["hour"] > 0) answerHour = $"{split["hour"]} hour{AddSifSuperiorTo1(split["hour"])}";
    if (split["minute"] > 0) answerMinute = $"{split["minute"]} minute{AddSifSuperiorTo1(split["minute"])}";
    if (split["second"] > 0) answerSecond = $"{split["second"]} second{AddSifSuperiorTo1(split["second"])}";

    if (split["second"] > 0) answerSecond = "and " + answerSecond;
    else if (split["minute"] > 0) answerMinute = "and " + answerMinute;
    else if (split["hour"] > 0) answerHour = "and " + answerHour;
    else if (split["day"] > 0) answerDay = "and " + answerDay;
    return answerYear;
  }

  private static string AddSpaceBetweenSplits(List<string> splitList)
  {
    string answer = "";
    if (splitList.Count >= 2)
    {
      for (int i = 0; i < splitList.Count - 1; i++)
      {
        if (i < splitList.Count - 2)
        {
          answer += splitList[i] + ", ";
        }
        else
        {
          answer += splitList[i] + " ";
        }

      }
      answer += splitList[splitList.Count - 1];
    }
    else
    {
      answer = splitList[0];
    }
    return answer;
  }

  private static string AddSifSuperiorTo1(int splitInt)
  {
    if (splitInt > 1) return "s";
    else return "";
  }
}