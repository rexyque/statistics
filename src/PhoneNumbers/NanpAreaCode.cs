using System;

namespace RexyQue.Statistics.PhoneNumbers
{
    public struct NanpAreaCode
    {
        private NanpAreaCode(
            string id,
            NanpAreaCodeType type,
            bool assignable,
            bool assigned,
            string location,
            string country,
            bool inService)
        {
            Id = id;
            Type = type;
            Assignable = assignable;
            Assigned = assigned;
            Location = location;
            Country = country;
            InService = inService;
        }

        public string Id { get; }
        public NanpAreaCodeType Type { get; }
        public bool Assignable { get; }
        public bool Assigned { get; }
        public string Location { get; }
        public string Country { get; }
        public bool InService { get; }

        public override bool Equals(object obj)
        {
            return obj?.GetType() == typeof(NanpAreaCode)
                ? ((NanpAreaCode)obj).Id == Id 
                : false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static NanpAreaCode Parse(
            string id,
            string assignable,
            string assigned,
            string location,
            string country,
            string inService)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (assignable is null)
            {
                throw new ArgumentNullException(nameof(assignable));
            }
            if (assigned is null)
            {
                throw new ArgumentNullException(nameof(assigned));
            }
            if (inService is null)
            {
                throw new ArgumentNullException(nameof(inService));
            }

            if (id.Length != 3)
            {
                throw new ArgumentException($"Argument length must be 3 characters. Length was {id.Length} characters", nameof(id));
            }

            return new NanpAreaCode(
                id,
                id[1] == id[2]
                    ? NanpAreaCodeType.EasilyRecognizable
                    : NanpAreaCodeType.GeneralPurpose,
                assignable == "Yes",
                assigned == "Yes",
                location,
                country,
                inService == "Y");
        }
    }

    public enum NanpAreaCodeType
    {
        GeneralPurpose,
        EasilyRecognizable
    }
}
