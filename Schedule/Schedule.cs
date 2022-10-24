using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, Count
    }
    class Schedule
    {
        public String MyMemo { get; set; }
        private DayOfWeek mMyDayOfWeek { get; set; }
        public DayOfWeek MyDayOfWeek
        {
            get
            {
                return mMyDayOfWeek;
            }
            set
            {
                if(value == DayOfWeek.Sunday)
                {
                    mMyDayOfWeek = DayOfWeek.Monday;
                }
                else
                {
                    mMyDayOfWeek = value;
                }
            }
        }

        private DateTime mMyTime;
        public DateTime MyTime
        {
            get
            {
                return mMyTime;
            }
            set
            {
                if (value.Hour > 18 || value.Hour < 9)
                {
                    mMyTime = new DateTime(1, 1, 1, 9, 0, 0);
                }
                else
                {
                    mMyTime = value;
                }
            }
        }
        
    
        public Schedule(DayOfWeek myDayOfWeek, DateTime myTime, String myMemo)
        {
            this.MyDayOfWeek = myDayOfWeek;     //this 안써도 되지만 가시성이 더 좋아보여서..
            this.MyTime = myTime;
            this.MyMemo = myMemo;
        }
    }
}
