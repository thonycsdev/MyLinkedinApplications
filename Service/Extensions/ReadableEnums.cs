using Service.Enums;

namespace Service.Extensions
{
    public static class ReadableEnums
    {
        public static string ToReadableString(this Status status)
        {
            var dict = new Dictionary<Status, string>(){
                {Status.Accepted, "Accepted"},
                {Status.Applied, "Applied"},
                {Status.Interview, "Interview"},
                {Status.Offer, "Offer"},
                {Status.Rejected, "Rejected"}
            };

            return dict[status];
        }

        public static string ToReadableString(this Types status)
        {
            var dict = new Dictionary<Types, string>(){
                {Types.Hybrid, "Hybrid"},
                {Types.Presential, "Presential"},
                {Types.Remote, "Remote"},

            };

            return dict[status];
        }
    }
}