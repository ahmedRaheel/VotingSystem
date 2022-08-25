using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VotingSystem.Domain.Entities;
using VotingSystem.Infrastructure.Data;

namespace VotingSystem.Infrastructure.SeedData
{
    /// <summary>
    ///     VotingSystemContextSeed
    /// </summary>
    public class VotingSystemContextSeed
    {
        private readonly ILogger<VotingSystemContextSeed> _logger;
        private readonly VotingSystemContext _context;

        /// <summary>
        ///   Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public VotingSystemContextSeed(ILogger<VotingSystemContextSeed> logger, VotingSystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }
        public async Task TrySeedAsync()
        {
           if (!_context.State.Any()) 
                {
                    _context.State.Add(new Domain.Entities.State 
                    { 
                        Code = "AB", 
                        Name = "Test State1",
                        Cities = new List<City>() 
                        {
                            new City 
                            {
                                Code = "CT1", 
                                Name = "Test City1"
                            },
                            new City 
                            {
                                Code = "CT2", 
                                Name = "Test City2"
                            }
                        }
                    });
                    await _context.SaveChangesAsync();
                }
               if (!_context.PartySymbol.Any())
               {
                    _context.PartySymbol.Add(new PartySymbol
                    { 
                        Code = "Symbol1", 
                        Name = "BAT "
                       
                    });
                     await _context.SaveChangesAsync();
                    _context.PartySymbol.Add(new PartySymbol
                    { 
                        Code = "Symbol2", 
                        Name = "LION "
                       
                    });                   
                     await _context.SaveChangesAsync();
               }
               if(!_context.Party.Any())
               {
                    _context.Party.Add(new Party
                    { 
                       FullName  = "Right Hand Party",
                       ShortName = "RHP",
                       PartySymbolId = 1                        
                       
                    });
                    await _context.SaveChangesAsync();
                    _context.Party.Add(new Party
                    { 
                       FullName  = "Left Hand Party",
                       ShortName = "LHP",
                       PartySymbolId = 2                        
                       
                    });
                    await _context.SaveChangesAsync();
                }    
        }
    }
}