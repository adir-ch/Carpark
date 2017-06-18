using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Carpark.Engine.RateRepository.Rates
{
    public enum ParkingRateCode
    {
        [Display(Name = "Early bird rate")]
        EarlyBird,

        [Display(Name = "Night rate")]
        NightRate,

        [Display(Name = "Weekend rate")]
        WeekendRate,

        [Display(Name = "Standard rate")]
        StandardHourRate,

        [Display(Name = "Standard rate")]
        StandardCalendarDayRate, 
    }
}
