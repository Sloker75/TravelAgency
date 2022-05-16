using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class HotelAddressRepository : BaseRepository<HotelAddress>
    {
        public HotelAddressRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

    }
}
