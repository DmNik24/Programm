using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class StudyClass
    {
        private int _totalLearners;

        public byte Number { get; set; } // 1-11
        public string Title { get; set; } //"А", "Б" и т.п
        public Teacher Teacher { get; set; }
        public List<Learner> LearnerList { get; set; }
        public int TotalLearners { get { return _totalLearners; } private set { _totalLearners = LearnerList.Count(); } }
    }
}
