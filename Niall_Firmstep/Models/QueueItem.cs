using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niall_Firmstep.Models
{
    public enum Title{ _,Mr, Ms, Mrs, Miss, Dr};
    public enum Service {_,Housing,Benefits, [Display(Name = "Council Tax")]CouncilTax,
        [Display(Name = "Fly Tipping")] Flytipping, [Display(Name = "Missed Bin")]MissedBin };

    //public enum ClientType { Citizen, Organisation, Anonymous}
    public class QueueItem
    {
        public int ID { get; set; }
        public Boolean Served { get; set; }
        [DisplayName("Time Arrived")]
        public String dateCreated { get; set; }

        [DisplayName("First/Company Name")]
        public String FirstName { get; set; }
        [DisplayName("Family Name")]
        public String LastName { get; set; }
        [DisplayName("Title")]
        public Title myTitle { get; set; }


        [DisplayName("Select a Service")]
        public Service service { get; set; }
        [DisplayName("Customer Type")]
        public String type { get; set; }

        public QueueItem()
        {
            
            Served = false;
            dateCreated = DateTime.Now.ToShortTimeString();

        }

        //public string GetEnumDescription(Type type, string value)
        //{
        //    return ((DescriptionAttribute)(type.GetMember(value)
        //        [0].GetCustomAttributes(typeof(DescriptionAttribute),
        //        false)[0])).Description;
        //}
        //public string ClientType { get; set; }







    }
}
