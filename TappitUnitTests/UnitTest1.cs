using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TappitTest;
using TappitTest.Controllers;

namespace TappitUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private IConfiguration Configuration { get; }
        private DatabaseContext _databaseContext { get; }
        public UnitTest1()
        {
            var builder = new ConfigurationBuilder()
            .AddUserSecrets<UnitTest1>();
            Configuration = builder.Build();
            _databaseContext = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(Configuration["Connectionstring"])
                .Options);
        }

        //Test to make sure that the API can handle an ID for a non-existant person
        [TestMethod]
        public void TestOutofRangePerson()
        {
            var SportController = new SportController(_databaseContext);
            var res = SportController.Person(-1)??null;
            Assert.IsNotNull(res);
            Assert.IsNull(res.Value);
        }
    }
}