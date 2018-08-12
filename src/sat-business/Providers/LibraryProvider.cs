using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sat_dal.Models;
using sat_contracts.repositories;
using sat_contracts.models;


namespace sat_business.Providers
{
    public class LibraryProvider : BaseProvider
    {
        public LibraryProvider(IGameSchemaRepo _gsr)
         : base("AE24AB02B6610D51BA9C8EA4128D11F3")
        {
           // this._gameSchemaRepo = _gsr;
        }
    }
}
