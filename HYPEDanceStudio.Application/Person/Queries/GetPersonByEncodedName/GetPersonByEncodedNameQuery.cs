using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Queries.GetPersonByEncodedName
{
    public class GetPersonByEncodedNameQuery : IRequest<PersonDto>
    {     
        public string EncodedName { get; set; }
        public GetPersonByEncodedNameQuery( string encodedName) 
        {
            EncodedName = encodedName;
        }

   
    }
}
