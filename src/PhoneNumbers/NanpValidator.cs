using System;

namespace RexyQue.Statistics.PhoneNumbers
{
    /// <summary>
    /// A group of methods for dealing with phone numbers which are part of the North
    /// American Numbering Plan (NANP).
    /// </summary>
    /// <remarks>
    /// This class only validates if a string of characters is a valid number according
    /// to the numbering schema used by the NANP. It does NOT check if a number
    /// is currently assigned or even assignable.
    /// </remarks>
    public class NanpValidator
    {
        private readonly int[] _letterMap;

        public NanpValidator()
        {
            _letterMap = new int[] { 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 9, 9, 9, 9 };
        }

        private int GetNumber(char letter)
        {
            return _letterMap[char.ToUpper(letter) - 65]; // ASCII for 'A'
        }
    }
}
