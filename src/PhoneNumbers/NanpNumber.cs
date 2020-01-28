using System;
using System.Collections.Generic;
using System.Text;

namespace RexyQue.Statistics.PhoneNumbers
{
    /// <summary>
    /// Represents a valid ten-digit phone number under the North American Numbering 
    /// Plan (NANP).
    /// </summary>
    /// <remarks>
    /// While there are valid NANP phone numbers which are less than ten digits (ex. 911),
    /// this class is designed for use with ten-digit numbers only since those special
    /// numbers aren't present in the datasets I need to work with.
    /// </remarks>
    public class NanpNumber
    {
    }
}
