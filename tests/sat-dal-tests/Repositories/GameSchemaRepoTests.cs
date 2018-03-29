using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace sat_dal_tests.Repositories
{
    public class GameSchemaRepoTests
    {

        sat_dal.ModelContext db;
        sat_dal.Repositories.GameSchemaRepo _repo;


        public GameSchemaRepoTests()
        {
            var builder = new DbContextOptionsBuilder()
              .UseInMemoryDatabase();

            this.db = new sat_dal.ModelContext(builder.Options);
            this._repo = new sat_dal.Repositories.GameSchemaRepo(this.db);





        }


        [Fact]
        public async void SaveGameSchema()
        {

            long appId = 12345;
            var dummyGame = Utilities.getDummyGame();
            var dummyAchievements = Utilities.getDummyAchievementPercentages();

            var t = await this._repo.Load(appId);


            var testVar = await this._repo.SaveGameSchema(appId, dummyGame, dummyAchievements);

            Assert.Equal(testVar.AppId, appId);
            Assert.Equal(testVar.Name, dummyGame.GameName);




            // sat_dal.ModelContext db = new sat_dal.ModelContext( { })
            //sat_dal.Repositories.GameSchemaRepo repo = new sat_dal.Repositories.GameSchemaRepo();
            //var builder = new DbContextOptionsBuilder()
            //  .UseInMemoryDatabase();

            //sat_dal.ModelContext db = new sat_dal.ModelContext(builder.Options);



            // (long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch)
            //this.db

        }
    }
}
