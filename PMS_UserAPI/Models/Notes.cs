using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Models
{
    public class Notes
    {
        [Key]
        public int NoteId { get; set; }
        public int RecipientEmployeeID { get; set; }
        public int SenderEmployeeID { get; set; }
        public bool Urgency { get; set; }
        public string MessageDescription { get; set; }
        public string NotesStatus { get; set; }
        public bool DeleteFlag { get; set; }
        public string CreatedBy{ get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedOn { get; set; }
        public Nullable<int> ResponseNotesID { get; set; }


    }
}
