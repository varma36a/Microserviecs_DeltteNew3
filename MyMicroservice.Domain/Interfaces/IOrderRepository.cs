﻿using MyMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMicroservice.Domain.Interfaces
{

    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
