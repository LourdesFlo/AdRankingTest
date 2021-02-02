using coding_test_ranking.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace coding_test_ranking.Domain
{
    public abstract class Ad
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Picture> Pictures { get; set; }
        public int? HouseSize { get; set; }
        public DateTime? IrrelevantSince { get; set; }
        public int Score { get; set; }

        public List<IRule> Rules { get; set; }

        public abstract AdTypologyEnum getTypology();
        public int getScore()
        {
            return Rules.Sum(x => x.Evaluate(this));
        }
    }
}
