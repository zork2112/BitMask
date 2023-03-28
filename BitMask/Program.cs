// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

var returnCode = 10;

var returnCodeFlag = (ExceptionList)returnCode; // can cast int directly Enum 

Array values = Enum.GetValues(typeof(ExceptionList)); // Create an array to iterate through Enum (seq not guaranteed)

// Checking a specific flag 
var flagToCheck = ExceptionList.InvalidEmail;
Console.WriteLine(flagToCheck.ToString() + ": "+ returnCodeFlag.HasFlag(flagToCheck));

// This iterates the flags passing in different return code values from 0 to 31

for (int i = 0; i < 32; i++)
{
    Console.WriteLine("ReturnCode:" + i);
    PrintFlagList((ExceptionList)i, values);
    Console.WriteLine(new string('-', 20));
}

static void PrintFlagList(ExceptionList rc, Array values)
{
    foreach (ExceptionList val in values)
    {
        var output = val.ToString() + " : ";
        output += rc.HasFlag(val) ? "Yes" : "No";
        Console.WriteLine(output);
    }
}


// Take a look a this from Microsoft regarding Flags https://t.ly/YyG_
[Flags]
enum ExceptionList : short
{
    MissingContact = 1,
    DuplicateEntry = 2,
    BlankPlanCode = 4,
    InvalidEmail = 8,
    InvalidPhoneNumber = 16
}


