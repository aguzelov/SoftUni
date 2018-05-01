// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        private ISetController controller;

        [Test]
        public void Test()
        {
            //Arrange
            IStage stage = new Stage();
            ISet set = new Medium("testSet");

            IPerformer performer = new Performer("pencho", 3);
            performer.AddInstrument(new Guitar());

            ISong song = new Song("testSong", new System.TimeSpan(0, 0, 2));

            set.AddPerformer(performer);
            set.AddSong(song);

            stage.AddSet(set);
            this.controller = new SetController(stage);

            string expectedEnd = "-- Set Successful";
            string expectedSongText = "-- 1. testSong (00:02)";

            //Act
            string actual = this.controller.PerformSets();

            //Assert
            Assert.IsTrue(actual.Contains(expectedEnd));
            Assert.IsTrue(actual.Contains(expectedSongText));
        }

        [Test]
        public void TestWithBrokenInstrument()
        {
            //Arrange
            string expected = "-- Did not perform";

            IStage stage = new Stage();
            ISet set = new Long("testSet");

            IPerformer performer = new Performer("pencho", 3);
            performer.AddInstrument(new Microphone());

            ISong song = new Song("testSong", new System.TimeSpan(0, 1, 2));

            set.AddPerformer(performer);
            set.AddSong(song);

            stage.AddSet(set);
            this.controller = new SetController(stage);

            this.controller.PerformSets();
            this.controller.PerformSets();

            //Act
            string actual = this.controller.PerformSets();

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void TestOrderMultipleSong()
        {
            //Arrange
            string expectedEnd = "1. set:\r\n-- 1. firstSong (00:01)\r\n-- 2. secondSong (00:02)\r\n-- 3. thurdSong (00:03)\r\n-- Set Successful\r\n2. secondSet:\r\n-- Did not perform";

            IStage stage = new Stage();
            ISet set = new Medium("set");

            IPerformer performer = new Performer("pencho", 3);
            performer.AddInstrument(new Guitar());

            ISong firstSong = new Song("firstSong", new System.TimeSpan(0, 0, 1));
            ISong secondSong = new Song("secondSong", new System.TimeSpan(0, 0, 2));
            ISong thurdSong = new Song("thurdSong", new System.TimeSpan(0, 0, 3));

            set.AddPerformer(performer);
            set.AddSong(firstSong);
            set.AddSong(secondSong);
            set.AddSong(thurdSong);

            ISet secondSet = new Long("secondSet");
            IPerformer secondPerformer = new Performer("Mincho", 20);
            performer.AddInstrument(new Microphone());
            ISong secondPerformerFirstSong = new Song("secondFirstSong", new System.TimeSpan(0, 0, 1));
            ISong secondPerformerSecondSong = new Song("secondSecondSong", new System.TimeSpan(0, 0, 2));
            secondSet.AddPerformer(secondPerformer);
            secondSet.AddSong(secondPerformerFirstSong);
            secondSet.AddSong(secondPerformerSecondSong);

            stage.AddSet(set);
            stage.AddSet(secondSet);
            this.controller = new SetController(stage);

            //Act
            string actual = this.controller.PerformSets();

            //Assert
            Assert.IsTrue(actual.Contains(expectedEnd));
        }
    }
}