﻿using MCard40.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Infrastucture.Services.Interfaces
{
    public interface IWorkDayService
    {
        public List<WorkDay> GetAll();
        void Add(WorkDay workDay);
        WorkDay GetById(int? id);
        WorkDay Update(int id, WorkDay workDay);
        WorkDay GetWorkDayDetails(int? id);
        WorkDay Delete(int id);
    }
}
