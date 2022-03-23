using System.Collections.Generic;

namespace CinemaTickets.Data.ViewModels.Email
{
    public class UserEmailOptionsViewModel
    {
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public List<KeyValuePair<string,string>> Placeholders { get; set; }

    }
}
