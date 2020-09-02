using RailtownBE5Assignment.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RailtownBE5Assignment.Services.Test
{
    public class GeoLocationServiceTests
    {
        [Fact]
        public async Task GetFarthestDistance()
        {
            IGeoLocationService service = new GeoLocationService();

            GeoLocationResult result = service.GetFarthestUsers(CreateMockUsers());

            Assert.Equal("Vancouver", result.UserOne.Name);
            Assert.Equal("Toronto", result.UserTwo.Name);

            //Google says 3364 km
            //Searched "distance from vancouver to toronto by flight"

            //https://www.movable-type.co.uk/scripts/latlong.html says 3362 km with
                //Toronto : 43 39 3.8 N, 79 20 49.2 W
                //Vancouver : 49 14 46.6 N, 123 6 58.4 W
            Assert.Equal(3362, Math.Round(result.Distance));
        }

        /// <summary>
        /// Returns first google results for McDonalds locations in Vancouver, Calgary, and Toronto
        /// </summary>
        /// <returns></returns>
        public IUser[] CreateMockUsers()
        {

            User vancouver = new User
            {
                Address = new Models.Address
                {
                    City = "Vancouver",
                    Street = "Georgia Street",
                    Zipcode = "V6E 3P2",
                    Geo = new Models.GeoLocation
                    {
                        Lat = 49.246292,
                        Lng = -123.116226
                    }
                },
                Company = new Models.Company
                {
                    Bs = "First McDonalds Vancouver",
                    CatchPhrase = "Bada bababa",
                    Name = "McDonalds"
                },
                Name = "Vancouver",
                Id = "1",
                Phone = "604-718-1115"
            };

            User calgary = new User
            {
                Address = new Models.Address
                {
                    City = "Calgary",
                    Street = "2740 32 Ave NE",
                    Zipcode = "T1Y 2S2",
                    Geo = new Models.GeoLocation
                    {
                        Lat = 51.049999,
                        Lng = -114.06666
                    }
                },
                Company = new Models.Company
                {
                    Bs = "First McDonalds Calgary",
                    CatchPhrase = "Bada bababa",
                    Name = "McDonalds"
                },
                Name = "Calgary",
                Id = "2",
                Phone = "403-293-0256"
            };

            User toronto = new User
            {
                Address = new Models.Address
                {
                    City = "Toronto",
                    Street = "356 Yonge Street",
                    Zipcode = "M5B 1S5",
                    Geo = new Models.GeoLocation
                    {
                        Lat = 43.651070,
                        Lng = -79.347015
                    }
                },
                Company = new Models.Company
                {
                    Bs = "First McDonalds Toronto",
                    CatchPhrase = "Bada bababa",
                    Name = "McDonalds"
                },
                Name = "Toronto",
                Id = "3",
                Phone = "416-596-2231"
            };

            return new IUser[] { vancouver, calgary, toronto };
        }
    }
}