using Core.Context;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CardService : BaseService<Card, Guid>, ICardService
    {
        public CardService(SchedulerContext context) : base(context)
        {
        }
    }
}

