using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenTidl.Methods;
using TidalInfra;

namespace TidalTests.ComponentTests
{
    [TestFixture]
    public class LoginComponentTests
    {
        LoginLogic loginLogic;

        [SetUp]
        public void InitTest()
        {
            loginLogic = new LoginLogic();
            var client = loginLogic.GetClient();
            Assert.IsNotNull(client);
        }


        [Test]
        public async Task  BasicLoginTest()
        {
            OpenTidlSession res = await loginLogic.BaseLogin();
            Assert.IsNotNull(res);
        }

        [Test]
        public async Task TestLogin()
        {
            const string title = "Test";
            OpenTidlSession tidlSession = await loginLogic.BaseLogin();
            PlaylistLogic playlistLogic = new PlaylistLogic(tidlSession);
            var res  =  await playlistLogic.CreateUserPlaylistWithTitle("Test");
            Assert.AreEqual(title, res.Title);
        }

        [Test]
        public async Task TestAddPlaylistTracks()
        {
            const string playlistETag = "Demo";
            OpenTidlSession tidlSession = await loginLogic.BaseLogin();
            PlaylistLogic playlistLogic = new PlaylistLogic(tidlSession);
            List<int> mockIds = new List<int> { 1, 2, 3 };
            var res  = await playlistLogic.AddPlaylistTracks(playlistETag, mockIds, 0);
            Assert.AreEqual(playlistETag, res.ETag);
        }
    }
}
