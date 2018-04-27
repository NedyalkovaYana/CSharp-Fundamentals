﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BashSoft.Contracts;

namespace BashSoft
{
    public class RepositoryFilter : IDataFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }
        }
        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in studentsWithMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }
               
                if (givenFilter(userName_Points.Value))
                {
                    OutputWriter.PrintStudent
                        (new KeyValuePair<string, double>
                        (userName_Points.Key, userName_Points.Value));
                    counterForPrinted++;
                }
            }
        }     
    }
}
