﻿using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.Models
{
    public class Course : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;

        private Dictionary<string, IStudent> studentsByName;


        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return studentsByName; }
        }

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.Username))
            {
                throw new DuplicateEntryInStructureException(student.Username, this.name);
            }

            this.studentsByName.Add(student.Username, student);
        }
   
        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);
        public override string ToString() => this.Name;
    }
}
