﻿using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        public void Add(IPlayer p_new)
        {
            throw new NotImplementedException();
        }

        public void CreatePlayer(string v)
        {
            throw new NotImplementedException();
        }

        public void Delete(IPlayer p_del)
        {
            throw new NotImplementedException();
        }

        public IList<IPlayer> Get()
        {
            throw new NotImplementedException();
        }

        public IPlayer Get(IPlayer p_get)
        {
            throw new NotImplementedException();
        }

        public void Update(IPlayer p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<IPlayer> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
