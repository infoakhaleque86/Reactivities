using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
      public class Query : IRequest<List<Activity>> {}

      public class Handler : IRequestHandler<Query, List<Activity>>
        {
        private readonly DataContext _Context;

            public Handler(DataContext Context)
            {
             _Context = Context;  
            }
            
            public async Task<List<Activity>> Handle(Query request, CancellationToken token)
            {   
               return await _Context.Activities.ToListAsync();
            }
        }
    }
}