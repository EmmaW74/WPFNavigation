using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNavigation.Model
{
    class DateObject
    {
        private DateTime? mySelectedDateProperty = null;

        public DateTime? MySelectedDateProperty
        {
            get { 
                return mySelectedDateProperty; 
            }
            set { 
                mySelectedDateProperty = value; 
            }
        }

        public DateTime? MyStartDateProperty { get; set; } = null;

        public DateTime? MyEndDateProperty { get; set; } = null;

        public DateTime? MyDisplayDateProperty { get; set; } = null;

        public DateTime? MyDefaultDateProperty { get; set; } = null;

        public DateObject()
        {
            try
            {
                MyDisplayDateProperty = DateTime.Parse("2023-06-01"); //Date the calendar defaults to on opening (even if there's a selected date). Doesn't show in box. Calendar display starts at today if this is null.
                //MySelectedDateProperty = DateTime.Parse("2022-11-01"); //Shows in box, shows as selected on calendar but calendar still opens on DisplayDate.
                MyStartDateProperty = DateTime.Parse("1970-01-01"); //Sets start date of calendar, display date is still used on opening
                //MyEndDateProperty = DateTime.Parse("2000-06-01"); //Sets end date of calendar, display date is still used on opening

            }
            catch { }
        }
    }
}
