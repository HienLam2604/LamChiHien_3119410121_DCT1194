using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pay1193.Entity
{
    public enum Month
    {
        //January, February, March, April, May, June, July, August, September, October, November,December
        [Display(Name = "January")]
        January = 1,
        [Display(Name = "February")]
        February = 2,
        [Display(Name = "March")]
        March = 3,
        [Display(Name = "April")]
        April = 4,
        [Display(Name = "May")]
        May = 5,
        [Display(Name = "June")]
        June = 6,
        [Display(Name = "July")]
        July = 7,
        [Display(Name = "August")]
        August = 8,
        [Display(Name = "September")]
        September = 9,
        [Display(Name = "October")]
        October = 10,
        [Display(Name = "November")]
        November = 11,
        [Display(Name = "December")]
        December = 12,
    }

}