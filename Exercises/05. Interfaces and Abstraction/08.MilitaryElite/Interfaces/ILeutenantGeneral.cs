using System.Collections.Generic;

public interface ILeutenantGeneral
{
    IList<Private> PrivatesUnderCommand
    {
        get;
    }
}