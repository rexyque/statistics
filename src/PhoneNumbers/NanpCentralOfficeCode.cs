using System;

namespace RexyQue.Statistics.PhoneNumbers
{
    public struct NanpCentralOfficeCode
    {
        private NanpCentralOfficeCode(
            string id,
            NanpCentralOfficeCodeUse use,
            bool? inService)
        {
            Id = id;
            Use = use;
            InService = inService;
        }

        private static NanpCentralOfficeCodeUse ParseUse(string use)
        {
            switch (use)
            {
                case "AS":
                    return NanpCentralOfficeCodeUse.Assigned;
                case "PR":
                    return NanpCentralOfficeCodeUse.Protected;
                case "RV":
                    return NanpCentralOfficeCodeUse.Reserved;
                case "UA":
                    return NanpCentralOfficeCodeUse.Unavailable;
                case "VC":
                    return NanpCentralOfficeCodeUse.Vacant;
                default:
                    throw new ArgumentException($"Unrecognized use code '{use}'", nameof(use));
            }
        }

        public string Id { get; }
        public NanpCentralOfficeCodeUse Use { get; }
        public bool? InService { get; }

        public override bool Equals(object obj)
        {
            return obj?.GetType() == typeof(NanpCentralOfficeCode)
                ? ((NanpCentralOfficeCode)obj).Id == Id 
                : false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static NanpCentralOfficeCode Parse(string id, string use, string inService)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (use is null)
            {
                throw new ArgumentNullException(nameof(use));
            }

            if (id.Length != 3)
            {
                throw new ArgumentException($"Argument length must be 3 characters. Length was {id.Length} characters", nameof(id));
            }

            return new NanpCentralOfficeCode(
                id,
                ParseUse(use),
                !string.IsNullOrWhiteSpace(inService)
                    ? inService == "Yes"
                    : (bool?)null);
        }
    }

    public enum NanpCentralOfficeCodeUse
    {
        Assigned,
        Protected,
        Reserved,
        Unavailable,
        Vacant
    }
}
