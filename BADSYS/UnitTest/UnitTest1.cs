using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL;
using DAL;
using Models;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            // use fake database
            ParticipationManager pm = new ParticipationManager(new FakeDAL());

            // act
            Participation participation = pm.AddParticipant(new Participation(1, 2));

            // assert
            Assert.Equals(participation, Participation(1, 2));
        }
    }
}