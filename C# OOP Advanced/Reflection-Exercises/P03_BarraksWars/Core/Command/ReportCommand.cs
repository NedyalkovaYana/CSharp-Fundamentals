using System;
using System.Collections.Generic;
using System.Text;
using P03_BarraksWars.Attributes;
using P03_BarraksWars.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public  class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;
        public ReportCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute() => this.repository.Statistics;
    }
}
